using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;


namespace infusync.Security
{

    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUser()
        {
            // Debug.Write(_context.HttpContext.User);
            //return "eb5d17b2-e4e8-470f-8436-ae5a10dd8eba";
            if (IsUserLoggedIn())
                return ObjectId.Parse(_context.HttpContext.User?.Claims.Where(c => c.Type == "sub").FirstOrDefault().Value).ToString();
            return ObjectId.Parse("465724b4-488e-4efa-ae73-a99d3809d3db").ToString();
        }



        public bool IsUserLoggedIn()
        {
            var context = _context.HttpContext;
            return context.User.Identities.Any(x => x.IsAuthenticated);
        }

        public IEnumerable<string> GetRoles()
        {
            return _context.HttpContext.User?.Claims
                .Where(c => c.Type == "role")
                .Select(c => c.Value);
        }

        public string GetUserName()
        {
            return _context.HttpContext.User?.Claims.Where(c => c.Type == "name").FirstOrDefault().Value;
        }

        public string GetCurrentCompany()
        {
            if (IsUserLoggedIn())
                return ObjectId.Parse(_context.HttpContext.User?.Claims.Where(c => c.Type == "company_id").FirstOrDefault().Value).ToString();
            return ObjectId.Empty.ToString();
        }

        public string GetUserRole()
        {
            return _context.HttpContext.User?.Claims
                .Where(c => c.Type == "role")
                .Select(c => c.Value).FirstOrDefault();
        }

        public bool IsAdmin()
        {
            throw new NotImplementedException();
        }
    }

    public interface IUserResolverService
    {
        string GetUser();
        IEnumerable<string> GetRoles();
        string GetUserName();
        string GetCurrentCompany();
        string GetUserRole();
    }
}
