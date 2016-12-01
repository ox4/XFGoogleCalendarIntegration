using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3;
using Xamarin.Forms;
using XFGoogleCalendarIntegration.Constants;
using XFGoogleCalendarIntegration.Models;
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
            // Обработчик успешной авторизации
        }
    }
}
