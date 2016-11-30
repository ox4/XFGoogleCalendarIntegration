using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XFGoogleCalendarIntegration.Constants;

namespace XFGoogleCalendarIntegration.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<GoogleSignInPage, bool>(this, MessageNames.AuthStateChanged, OnAuthStateChange);
        }

        private void OnAuthStateChange(GoogleSignInPage sender, bool isAuthorized)
        {
        }
    }
}
