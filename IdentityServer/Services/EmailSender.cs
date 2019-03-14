using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationHost.Services
{
    public class EmailSender : IEmailSender
    {
        public IConfiguration Configuration { get; }
        private ILogger<EmailSender> m_logger;

        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {
            Configuration = configuration;
            m_logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.To.Add(new MailboxAddress(email));
            mimeMessage.From.Add(new MailboxAddress(Configuration["MailOptions:SenderName"], 
                Configuration["MailOptions:SenderUserName"]));
            mimeMessage.Subject = subject;
            TextFormat format = TextFormat.Html;
            mimeMessage.Body = new TextPart(format) { Text = message };

            await SendMessageAsync(mimeMessage);
        }

        private async Task SendMessageAsync(MimeMessage msg)
        {
            //try
            {
                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;


                    await client.ConnectAsync(Configuration["MailOptions:ServerAddress"], 
                        int.Parse(Configuration["MailOptions:ServerPort"]), Enum.Parse<SecureSocketOptions>(Configuration["MailOptions:SecureOption"]));

                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    if (!bool.Parse(Configuration["MailOptions:AddOAUTH"]))
                    {
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                    }

                    //await client.AuthenticateAsync(m_options.SenderUserName, m_options.SenderPassword);
                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(Configuration["MailOptions:SenderUserName"], Configuration["MailOptions:SenderPassword"]);

                    await client.SendAsync(msg);
                    m_logger.LogInformation($"Email Sent", msg);
                    await client.DisconnectAsync(true);
                }
            }
            
        }
    }
}
