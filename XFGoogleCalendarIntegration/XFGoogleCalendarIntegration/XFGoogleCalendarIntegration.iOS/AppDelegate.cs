using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Google.Core;
using Google.SignIn;
using UIKit;
using XFGoogleCalendarIntegration.Constants;

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
            // Client Id iOS приложения, созданного в Google API Console
            string clientId = "";
            SignIn.SharedInstance.ClientID = clientId;
            SignIn.SharedInstance.ServerClientID = GoogleApiConstants.ClientId;

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
