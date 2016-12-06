using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using Google.SignIn;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFGoogleCalendarIntegration.Constants;
using XFGoogleCalendarIntegration.CustomViews;
using XFGoogleCalendarIntegration.iOS.CustomRenderers;
using XFGoogleCalendarIntegration.Models;

[assembly: ExportRenderer(typeof(GoogleSignInButton), typeof(GoogleSignInButtonIos))]
namespace XFGoogleCalendarIntegration.iOS.CustomRenderers
{ 
    public class GoogleSignInButtonIos : ViewRenderer, ISignInUIDelegate, ISignInDelegate
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            var signInButton = new SignInButton();
            signInButton.Frame = new CGRect(20, 100, 150, 44);
            SignIn.SharedInstance.UIDelegate = this;
            SignIn.SharedInstance.Delegate = this;
            SignIn.SharedInstance.Scopes = new[]
            {
                GoogleApiConstants.Scope
            };
            this.SetNativeControl(signInButton);
            base.OnElementChanged(e);
        }

        public void DidSignIn(SignIn signIn, GoogleUser user, NSError error)
        {
            if (error == null)
            {
                var token = new AccessTokenModel()
                {
                    AccessToken = user.Authentication.AccessToken,
                    ExpiresIn = 3600,
                    TokenType = "Bearer"
                };

                MessagingCenter.Send<object, AccessTokenModel>(this, MessageNames.LoggedIn, token);
            }
        }

        [Export("signIn:presentViewController:")]
        public void PresentViewController(SignIn signIn, UIViewController viewController)
        {
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(viewController, true, null);
        }

        [Export("signIn:dismissViewController:")]
        public void DismissViewController(SignIn signIn, UIViewController viewController)
        {
            viewController.DismissViewController(true, null);
        }
    }
}