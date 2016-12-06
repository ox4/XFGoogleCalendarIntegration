using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XFGoogleCalendarIntegration.Models;
using XFGoogleCalendarIntegration.ViewModels;

namespace XFGoogleCalendarIntegration.Pages.Calendar
{
    public partial class CalendarPage 
    {
        public CalendarPage(AccessTokenModel token)
        {
            InitializeComponent();
            this.BindingContext = new CalendarViewModel(token);
        }
    }
}
