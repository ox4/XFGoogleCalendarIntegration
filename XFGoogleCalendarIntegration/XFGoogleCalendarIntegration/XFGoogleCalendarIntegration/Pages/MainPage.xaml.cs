using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFGoogleCalendarIntegration.Constants;
using XFGoogleCalendarIntegration.Models;
using XFGoogleCalendarIntegration.Models.Calendar;
using XFGoogleCalendarIntegration.Pages.Calendar;
using XFGoogleCalendarIntegration.Services;

namespace XFGoogleCalendarIntegration.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<object, AccessTokenModel>(this, MessageNames.LoggedIn, OnLogIn);
        }

        private void OnLogIn(object sender, AccessTokenModel token)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await this.Navigation.PushAsync(new CalendarPage(token));
            });
        }
    }
}
