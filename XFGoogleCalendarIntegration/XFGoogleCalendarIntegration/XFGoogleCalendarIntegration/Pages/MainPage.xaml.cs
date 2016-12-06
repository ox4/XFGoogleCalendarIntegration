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
                await this.Navigation.PushModalAsync(new CalendarPage(token));
            });
            //var service = new GoogleApiService(token);
            //
            //var request = new ListRequest()
            //{
            //    MaxResults = 4
            //};

            //var list = await service.GetAsync<ListRequest, Events>("https://www.googleapis.com/calendar/v3/calendars/primary/events", request);
            //// Обработчик успешной авторизации
        }
    }
}
