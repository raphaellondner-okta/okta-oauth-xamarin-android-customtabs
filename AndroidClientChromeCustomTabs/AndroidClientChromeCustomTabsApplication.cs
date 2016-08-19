using Android.App;
using Android.Runtime;
using System;

namespace Okta.Samples.OAuth.Xamarin
{
    [Application]
    public class OktaAndroidApplication : Application
    {
        public static ActivityMediator Mediator { get; } = new ActivityMediator();
        public OktaAndroidApplication(IntPtr handle, JniHandleOwnership transfer)
            : base(handle,transfer)
        {
            // constructor must be available for Application instance to work
        }
    }
}