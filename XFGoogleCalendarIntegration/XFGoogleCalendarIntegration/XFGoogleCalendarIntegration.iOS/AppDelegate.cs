using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Google.Core;
using Google.SignIn;
using UIKit;

namespace XFGoogleCalendarIntegration.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            string clientId = "192079722147-foetvqvjduvk6hh56uii4ep7lm5iiqu3.apps.googleusercontent.com";

            //NSError configureError;
            //Context.SharedInstance.Configure(out configureError);
            //if (configureError != null)
            //{
                SignIn.SharedInstance.ClientID = clientId;
                //SignIn.SharedInstance.ServerClientID = "192079722147-k89ga85nbbtj58p36msshrmh9i66phk9.apps.googleusercontent.com";
            //}

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            return SignIn.SharedInstance.HandleUrl(url, sourceApplication, annotation);
        }
    }
}
