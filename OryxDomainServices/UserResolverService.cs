using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Linq;


////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: OSSOSecurity.Services
//
// summary:	.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace OryxDomainServices
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   This service gets information about the currently logged on user for the httpContext </summary>
    ///
    /// <remarks>   Tayo, 19/03/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UserResolverService : IUserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(IHttpContextAccessor context)
        {
            _context = context;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the user id </summary>
        ///
        /// <remarks>   Tayo, 19/03/2018. </remarks>
        ///
        /// <returns>   The user. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetUser()
        {
            // Debug.Write(_context.HttpContext.User);
            return _context.HttpContext.User?.Claims.Where(c => c.Type == "sub").FirstOrDefault().Value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if the logged on is an super admin user. </summary>
        ///
        /// <remarks>   Tayo, 19/03/2018. </remarks>
        ///
        /// <returns>   True if admin, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsAdmin()
        {
            string admin = _context.HttpContext.User?.Claims.Where(c => c.Type == "role").FirstOrDefault().Value;
            return (admin == "Administrator") ? true : false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets logged on user name. </summary>
        ///
        /// <remarks>   Tayo, 19/03/2018. </remarks>
        ///
        /// <returns>   The user name. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GetUserName()
        {
            return _context.HttpContext.User?.Identity.Name;
        }

        public string GetUserRole()
        {
            string role = _context.HttpContext.User?.Claims.Where(c => c.Type == "role").FirstOrDefault().Value;
            return (role != string.Empty) ? role : string.Empty;
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Interface for user resolver service. </summary>
    ///
    /// <remarks>   Tayo, 19/03/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public interface IUserResolverService
    {
        string GetUser();
        string GetUserRole();
    }
}
