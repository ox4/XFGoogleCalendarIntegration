using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFGoogleCalendarIntegration.Models;
using XFGoogleCalendarIntegration.Services;

namespace XFGoogleCalendarIntegration.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private EventsListViewModel eventsListViewModel;

        public EventsListViewModel EventsListViewModel
        {
            get { return this.eventsListViewModel; }
            set
            {
                this.eventsListViewModel = value;
                this.OnPropertyChanged();
            }
        }

        public CalendarViewModel(AccessTokenModel token)
        {
            var googleApiService = new GoogleApiService(token);
            this.EventsListViewModel = new EventsListViewModel(googleApiService);
        }
    }
}
