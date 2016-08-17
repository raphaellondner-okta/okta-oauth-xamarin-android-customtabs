using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Support.CustomTabs;
using IdentityModel.OidcClient.WebView;
using System;
using System.Threading.Tasks;

namespace AndroidClientChromeCustomTabs
{

    class ChromeCustomTabsWebView : IWebView
    {
        public event EventHandler<HiddenModeFailedEventArgs> HiddenModeFailed;

        private readonly Activity _context;
        private CustomTabsActivityManager _customTabs;

        public ChromeCustomTabsWebView(Activity context)
        {
            _context = context;
        }

        public Task<InvokeResult> InvokeAsync(InvokeOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.StartUrl))
            {
                throw new ArgumentException("Missing StartUrl", nameof(options));
            }

            if (string.IsNullOrWhiteSpace(options.EndUrl))
            {
                throw new ArgumentException("Missing EndUrl", nameof(options));
            }

            // must be able to wait for the intent to be finished to continue
            // with setting the task result
            var _tcs = new TaskCompletionSource<InvokeResult>();

            // create & open chrome custom tab
            _customTabs = new CustomTabsActivityManager(_context);

            // build custom tab
            var builder = new CustomTabsIntent.Builder(_customTabs.Session)
               .SetToolbarColor(Color.Argb(255, 52, 152, 219))
               .SetShowTitle(true)
               .EnableUrlBarHiding();
            
            var customTabsIntent = builder.Build();

            // ensures the intent is not kept in the history stack, which makes
            // sure navigating away from it will close it
            customTabsIntent.Intent.AddFlags(ActivityFlags.NoHistory);

            ActivityMediator.MessageReceivedEventHandler callback = null;
            callback = (response) =>
            {
                // remove handler
                AndroidClientChromeCustomTabsApplication
                .Mediator.ActivityMessageReceived -= callback;

                // set result
                _tcs.SetResult(new InvokeResult
                {
                    Response = response,
                    ResultType = InvokeResultType.Success
                });

                // start MainActivity (will close the custom tab)
                _context.StartActivity(typeof(MainActivity));
            };

            // attach handler
            AndroidClientChromeCustomTabsApplication.Mediator.ActivityMessageReceived
                += callback;     

            // launch
            customTabsIntent.LaunchUrl(_context, Android.Net.Uri.Parse(options.StartUrl));

            // need an intent to be triggered when browsing to the "io.identitymodel.native://callback"
            // scheme/URI => CallbackInterceptorActivity
            return _tcs.Task;
        } 
    }
}