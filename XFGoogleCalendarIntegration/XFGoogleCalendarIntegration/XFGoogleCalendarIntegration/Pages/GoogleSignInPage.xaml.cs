using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XFGoogleCalendarIntegration.Constants;
using XFGoogleCalendarIntegration.Models;
using XFGoogleCalendarIntegration.Services;

namespace XFGoogleCalendarIntegration.Pages
{
    public partial class GoogleSignInPage : ContentPage
    {
        private readonly GoogleOAuthService googleOAuthService;
        public GoogleSignInPage()
        {
            this.googleOAuthService = new GoogleOAuthService();
            this.InitializeComponent();
            this.InitializeWebView();
        }

        private void InitializeWebView()
        {
            var webView = new WebView
            {
                Source = this.googleOAuthService.RequestUrl,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;
            Content = webView;
        }

        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var code = this.googleOAuthService.ExtractCodeFromUrl(e.Url);
            if (code != string.Empty)
            {
                var token = await this.googleOAuthService.GetAccessTokenAsync(code);
                MessagingCenter.Send<object, AccessTokenModel>(this, MessageNames.LoggedIn, token);
                await this.Navigation.PopModalAsync();
            }
        }
    }
}
