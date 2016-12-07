using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFGoogleCalendarIntegration.Constants;
using XFGoogleCalendarIntegration.Models.Calendar;
using XFGoogleCalendarIntegration.Services;

namespace XFGoogleCalendarIntegration.ViewModels
{
    public class EventsListViewModel : BaseViewModel
    {
        private readonly GoogleApiService googleApiService;
        private ObservableCollection<EventViewModel> events;
        private bool isRefreshing;

        public Command PullToRefreshCommand { get; set; }

        public ObservableCollection<EventViewModel> Events
        {
            get { return this.events; }
            set
            {
                this.events = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set
            {
                this.isRefreshing = value;
                this.OnPropertyChanged();
            }
        }

        public EventsListViewModel(GoogleApiService googleApiService)
        {
            this.googleApiService = googleApiService;
            this.PullToRefreshCommand = new Command(this.PullToRefresh, () => !this.IsRefreshing);
            this.UpdateList();
        }

        private async void PullToRefresh()
        {
            this.IsRefreshing = true;
            this.PullToRefreshCommand.ChangeCanExecute();

            await this.UpdateList();

            this.IsRefreshing = false;
            this.PullToRefreshCommand.ChangeCanExecute();
        }

        private async Task UpdateList()
        {
            var request = new ListRequest()
            {
                TimeMin = DateTime.Now
            };

            var events = await googleApiService.GetAsync<ListRequest, Events>(GoogleApiConstants.CalendarListRequestUrl, request, new Dictionary<string, string>()
            {
                { "calendarId", GoogleApiConstants.MainCalendarId }
            });
            var eventViewModels = this.EventsToViewModels(events.Items);
            this.Events = new ObservableCollection<EventViewModel>(eventViewModels);
        }

        private IEnumerable<EventViewModel> EventsToViewModels(IEnumerable<Event> events)
        {
            return events.Select(eventModel => new EventViewModel(eventModel));
        }
    }
}
