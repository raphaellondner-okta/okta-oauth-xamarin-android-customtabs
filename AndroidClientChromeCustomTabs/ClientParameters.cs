using IdentityModel.OidcClient;

namespace Okta.Samples.OAuth.Xamarin
{
    internal class ClientParameters
    {

        //Okta-specific parameters

        internal const string OAuthClientId = "79arVRKBcBEYMuMOXrYF";
        internal const string OAuthClientSecret = null;
        internal const string DataScheme = "com.oktapreview.example";
        internal const string DataHost = "oauth";
        internal static string OAuthRedirectUrl = string.Format(DataScheme + "://" + DataHost);
        internal const string OAuthAuthority = "https://example.oktapreview.com";
        internal const string OAuthScopes = "openid email profile address phone groups offline_access";
        internal const string ResourceServerApi = "https://localhost/api";
        internal const OidcClientOptions.AuthenticationStyle AuthStyle = OidcClientOptions.AuthenticationStyle.AuthorizationCode;


        //IdentityServer Demo parameters
        //internal const string OAuthClientId = "native";
        //internal const string OAuthClientSecret = "secret";
        //internal const string DataScheme = "io.identitymodel.native";
        //internal const string DataHost = "callback";
        //internal static string OAuthRedirectUrl = string.Format(DataScheme + "://" + DataHost);
        //internal const string OAuthAuthority = "https://demo.identityserver.io";
        //internal const string OAuthScopes = "openid profile api offline_access";
        //internal const string ResourceServerApi = "https://demo.identityserver.io/api";
        //internal const IdentityModel.OidcClient.OidcClientOptions.AuthenticationStyle AuthStyle = IdentityModel.OidcClient.OidcClientOptions.AuthenticationStyle.Hybrid;



    }
}