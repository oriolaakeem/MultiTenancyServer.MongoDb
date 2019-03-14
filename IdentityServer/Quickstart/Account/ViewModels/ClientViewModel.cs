namespace IdentityServer.Quickstart.Account.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        public int AccessTokenType { get; set; }

        public bool AllowAccessTokensViaBrowser { get; set; }

        //Array
        public string AllowedCorsOrigins { get; set; }

        //Array
        public string AllowedScopes { get; set; }

        public string ClientId { get; set; }

        public string ClientName { get; set; }

        //Array
        public string PostLogoutRedirectUris { get; set; }

        public string RedirectUris { get; set; } //Array

        public bool RequireConsent { get; set; }
    }
}