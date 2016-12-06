using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using XFGoogleCalendarIntegration.Models;
using XFGoogleCalendarIntegration.Services;

namespace XFGoogleCalendarIntegration.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private EventsListViewModel eventsListViewModel;
        private AddEventViewModel addEventViewModel;

        public EventsListViewModel EventsListViewModel
        {
            get { return this.eventsListViewModel; }
            set
            {
                this.eventsListViewModel = value;
                this.OnPropertyChanged();
            }
        }

        public AddEventViewModel AddEventViewModel
        {
            get { return this.addEventViewModel; }
            set
            {
                this.addEventViewModel = value;
                this.OnPropertyChanged();
            }
        }

        public CalendarViewModel(AccessTokenModel token)
        {
            var googleApiService = new GoogleApiService(token);
            this.EventsListViewModel = new EventsListViewModel(googleApiService);
            this.AddEventViewModel = new AddEventViewModel(googleApiService);
        }
    }
}
