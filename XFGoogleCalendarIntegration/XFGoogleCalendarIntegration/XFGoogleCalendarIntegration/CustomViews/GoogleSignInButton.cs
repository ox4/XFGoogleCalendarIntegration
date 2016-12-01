using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFGoogleCalendarIntegration.Pages;

namespace XFGoogleCalendarIntegration.CustomViews
{
    public class GoogleSignInButton : Button
    {
        public GoogleSignInButton()
        {
            this.Text = "Sign In via Google";
            this.Clicked += OnClicked;
        }

        private async void OnClicked(object sender, EventArgs eventArgs)
        {
            // Показываем страницу авторизации по клику на кнопку 
            await Navigation.PushModalAsync(new GoogleSignInPage());
        }
    }
}
