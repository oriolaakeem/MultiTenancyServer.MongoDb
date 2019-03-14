using System;
using System.Text;

namespace infusync.Security
{
    public class IdSvrSettings
    {
        public string GetIdLogin()
        {
            string clientId = "infusyncWebClient";
            string clientSecret = "F621F470-9731-4A25-80EF-67A6F7C5F4B8";
            var credentials = string.Format("{0}:{1}", clientId, clientSecret);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
        }
    }
}
