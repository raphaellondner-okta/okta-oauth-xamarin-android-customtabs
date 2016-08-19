
using Android.App;
using Android.Content;
using Android.OS;

namespace Okta.Samples.OAuth.Xamarin
{
    [Activity(Label = "CallbackInterceptorActivity")]
    [IntentFilter(
        new[] { Intent.ActionView },
        Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
        DataScheme = ClientParameters.DataScheme,
        DataHost = ClientParameters.DataHost)]
    public class CallbackInterceptorActivity :  Activity
    {       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Finish();

            // get URI, send with mediator
            OktaAndroidApplication.Mediator.Send(Intent.DataString);
        }
    }
}