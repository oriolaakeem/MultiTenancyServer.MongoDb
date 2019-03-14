// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using ApplicationHost.Configuration;
using ApplicationHost.Services;
using AspNetCore.Identity.MongoDbCore.Extensions;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using infusync.DataTier;
using infusync.DataTier.DbContexts;
using infusync.DataTier.Repository;
using Hangfire;
using Hangfire.Mongo;
using IdentityModel;
using IdentityServer4.MongoDB.Configuration;
using IdentityServer4.MongoDB.DbContexts;
using IdentityServer4.MongoDB.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using ondgo.identity;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ApplicationHost
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ILoggerFactory _loggerFactory;
        public IHostingEnvironment Environment { get; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }



        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //  if (this._loggerFactory == null)
            //this._loggerFactory = (ILoggerFactory) new LoggerFactory();

            //var cors = new DefaultCorsPolicyService(_loggerFactory.CreateLogger<DefaultCorsPolicyService>())
            //{
            //    AllowedOrigins = { "https://*.infusync.com" },
            //    AllowAll = true
            //};
            //services.AddSingleton<ICorsPolicyService>(cors);

            // options.AddPolicy("MyCorsPolicy",
            //    builder => builder
            //       .SetIsOriginAllowedToAllowWildcardSubdomains()
            //       .WithOrigins("https://*.infusync.com")
            //       .AllowAnyMethod()
            //       .AllowCredentials()
            //       .AllowAnyHeader()
            //       .Build()
            //    );


            var dbConf = new MongoDBConfiguration();
            if (Environment.IsDevelopment())
            {
                dbConf.ConnectionString = Configuration["MongoDB:LocalConnectionString"];
                dbConf.DatabaseName = Configuration["MongoDB:DatabaseName"];
            }
            else
            {
                dbConf.ConnectionString = Configuration["MongoDB:ConnectionString"];
                dbConf.DatabaseName = Configuration["MongoDB:DatabaseName"];
            }

            services.Configure<MongoDBConfiguration>(options =>
            {
                options.DatabaseName = dbConf.DatabaseName;
                options.ConnectionString = dbConf.ConnectionString;
            });

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddScoped<IPasswordHasher<ApplicationUser>, BCryptPasswordHasher<ApplicationUser>>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var mongoDbIdentityConfiguration = new MongoDbIdentityConfiguration
            {
                MongoDbSettings = new MongoDbSettings
                {
                    ConnectionString = dbConf.ConnectionString,
                    DatabaseName = dbConf.DatabaseName
                },

                IdentityOptionsAction = options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;

                    // Lockout settings
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    options.Lockout.MaxFailedAccessAttempts = 10;

                    // ApplicationUser settings
                    options.User.RequireUniqueEmail = true;
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@.-_";
                }
            };


            // Add Multi-Tenancy services.
            services.AddMultiTenancy<ApplicationTenant, ObjectId>()
                .AddRequestParsers(parsers =>
                {
                    // To test a domain parser locally, add a similar line 
                    // to your hosts file for each tenant you want to test
                    // For Windows: C:\Windows\System32\drivers\etc\hosts
                    // 127.0.0.1    tenant1.tenants.local
                    //parsers.AddSubdomainParser(".tenants.local");

                    parsers.AddChildPathParser("/tenants/");
                });
                

            services.ConfigureMongoDbIdentity<ApplicationUser, ApplicationRole, ObjectId>(mongoDbIdentityConfiguration);
                

            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<ApplicationTenant>();
            services.AddScoped<ApplicationUser>();
            services.AddScoped<ApplicationRole>();

            services.AddScoped<IApplicationUserDbContext, ApplicationUserDbContext>();
            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });




            services.AddTransient<IEmailSender, EmailSender>();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(72);
            });

            //services.AddTransient<IConfigurationDbContext, ConfigurationDbContext>();
            //services.AddTransient<IInitConfigFiles, InitConfigFiles>();

            var builder = services.AddIdentityServer()
                //.AddSigningCredential(cert)
                //.AddConfigurationStore(Configuration)
                //.AddOperationalStore(Configuration)
                //.AddAspNetIdentity<ApplicationUser>()
                
                .AddProfileService<ProfileService>();

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {

                X509Certificate2 cert = null;
                using (X509Store certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser))
                {
                    certStore.Open(OpenFlags.ReadOnly);
                    X509Certificate2Collection certCollection = certStore.Certificates.Find(
                        X509FindType.FindByThumbprint,
                        Configuration["Certificate:thumbprint"],
                        false);
                    // Get the first cert with the thumbprint
                    if (certCollection.Count > 0)
                    {
                        cert = certCollection[0];
                        Log.Logger.Information($"Successfully loaded cert from registry: {cert.Thumbprint}");
                    }
                }
                if (cert == null)
                {
                    cert = new X509Certificate2(Path.Combine(Environment.ContentRootPath, "a29c9cfbbc021387f22e906e9f22aeb.pfx"), "infusync");
                    Log.Logger.Information($"Falling back to cert from file. Successfully loaded: {cert.Thumbprint}");
                }

                builder.AddSigningCredential(cert);
            }

            services.AddAuthentication();
            //.AddGoogle(options =>
            //{
            //    options.ClientId = "708996912208-9m4dkjb5hscn7cjrn5u0r4tbgkbj1fko.apps.googleusercontent.com";
            //    options.ClientSecret = "wdfPY6t8H8cecgjlxud__4Gh";
            //});

            services.AddHangfire(x => x.UseMongoStorage(dbConf.ConnectionString, dbConf.DatabaseName));

            var cbuilder = new ContainerBuilder();

            cbuilder.RegisterType(typeof(ODDbContext))
              .As(typeof(IODDbContext))
              .InstancePerLifetimeScope();

            cbuilder.RegisterType(typeof(InitConfigFiles))
                .As(typeof(IInitConfigFiles))
                .InstancePerLifetimeScope();

            cbuilder.RegisterType(typeof(ConfigurationDbContext))
                .As(typeof(IConfigurationDbContext))
                .InstancePerLifetimeScope();

            cbuilder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            cbuilder.Populate(services);

            ApplicationContainer = cbuilder.Build();
            //GlobalConfiguration.Configuration.UseAutofacActivator(ApplicationContainer, false);
            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void Configure(IApplicationBuilder app)
        {
            InitializeDatabase(app);
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseIdentityServer();
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            app.UseMultiTenancy<ApplicationTenant>();
            app.UseMvcWithDefaultRoute();
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<IInitConfigFiles>().InitializeFiles();

                var roleService = serviceScope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
                var superAdmin = roleService.FindByNameAsync("Super Administrators").Result;
                if (superAdmin == null)
                {
                    superAdmin = new ApplicationRole
                    {
                        Name = "Super Administrators"
                    };
                    var result = roleService.CreateAsync(superAdmin).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                }

                var admin = roleService.FindByNameAsync("Administrators").Result;
                if (admin == null)
                {
                    admin = new ApplicationRole
                    {
                        Name = "Administrators"
                    };
                    var result = roleService.CreateAsync(admin).Result;
                    if (!result.Succeeded)
                        throw new Exception(result.Errors.First().Description);
                }

                var individuals = roleService.FindByNameAsync("Individuals").Result;
                if (individuals == null)
                {
                    individuals = new ApplicationRole
                    {
                        Name = "Individuals"
                    };
                    var result = roleService.CreateAsync(individuals).Result;
                    if (!result.Succeeded)
                        throw new Exception(result.Errors.First().Description);
                }

                var manager = roleService.FindByNameAsync("Managers").Result;
                if (manager == null)
                {
                    manager = new ApplicationRole
                    {
                        Name = "Managers"
                    };
                    var result = roleService.CreateAsync(manager).Result;
                    if (!result.Succeeded)
                        throw new Exception(result.Errors.First().Description);
                }

                var staff = roleService.FindByNameAsync("Staff").Result;
                if (staff == null)
                {
                    staff = new ApplicationRole
                    {
                        Name = "Staff"
                    };
                    var result = roleService.CreateAsync(staff).Result;
                    if (!result.Succeeded)
                        throw new Exception(result.Errors.First().Description);
                }

                var userMgr = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var sa = userMgr.FindByNameAsync("admin@outlook.com").Result;
                if (sa == null)
                {
                    sa = new ApplicationUser
                    {
                        UserName = "admin@outlook.com",
                        Email = "admin@outlook.com",
                        IsActive = true
                    };
                    var result = userMgr.CreateAsync(sa, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddToRoleAsync(sa, "Super Administrators").Result;
                    if (!result.Succeeded)
                        throw new Exception(result.Errors.First().Description);

                    var role = string.Empty;
                    var aliceRoles = userMgr.GetRolesAsync(sa).Result;

                    result = userMgr.AddClaimsAsync(sa, new Claim[]{
                        new Claim(JwtClaimTypes.Name, "Super Admin"),
                        new Claim(JwtClaimTypes.GivenName, "Superadmin"),
                        new Claim(JwtClaimTypes.FamilyName, "Administrator"),
                        new Claim(JwtClaimTypes.Role, string.Join(",", aliceRoles)),
                        new Claim(JwtClaimTypes.Email, "superadmin@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://ondgo.ng"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                    }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Console.WriteLine("SuperAdmin created");

                }
                else
                {
                    Console.WriteLine("SuperAdmin already exists");
                }
            }
        }
    }
}
