## Xamarin OAuth code sample using Chrome Custom Tabs

This code sample currently requires this [forked version of IdentityModel.OidcClient](https://github.com/raphaellondner-okta/IdentityModel.OidcClient/tree/rl-pkce-secretless) to correctly work with Okta.

Modify your client-specific parameters in __*ClientParameters.cs*__ to test this sample with your own OAuth client (tested with IdentityServer3 and Okta for now)