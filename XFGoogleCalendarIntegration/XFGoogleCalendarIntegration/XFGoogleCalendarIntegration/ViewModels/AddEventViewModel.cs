using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFGoogleCalendarIntegration.Extensions;
using XFGoogleCalendarIntegration.Models.Calendar;
using XFGoogleCalendarIntegration.Services;

namespace XFGoogleCalendarIntegration.ViewModels
{
    public class AddEventViewModel : BaseViewModel
    {
        private Event eventModel;
        private readonly GoogleApiService googleApiService;

        public AddEventViewModel(GoogleApiService googleApiService)
        {
            this.googleApiService = googleApiService;
            this.eventModel = new Event()
            {
                Start = new EventDateTime() { DateTime = DateTime.Now },
                End = new EventDateTime() { DateTime = DateTime.Now.AddHours(1) }
            };

            this.AddEventCommand = new Command(this.AddEvent);
        }

        public ICommand AddEventCommand { get; set; }

        public string Summary
        {
            get { return this.eventModel.Summary; }
            set { this.eventModel.Summary = value; }
        }

        public DateTime Date
        {
            get { return this.eventModel.Start.DateTime.Value.Date; }
            set
            {
                var start = this.eventModel.Start.DateTime.Value;
                var end = this.eventModel.End.DateTime.Value;
                this.eventModel.Start.DateTime = new DateTime(value.Year, value.Month, value.Month, start.Hour, start.Minute, start.Second);
                this.eventModel.End.DateTime = new DateTime(value.Year, value.Month, value.Month, end.Hour, end.Minute, end.Second);
            }
        }

        public TimeSpan StartTime
        {
            get { return this.eventModel.Start.DateTime.Value.TimeOfDay; }
            set
            {
                var start = this.eventModel.Start.DateTime.Value;
                this.eventModel.Start.DateTime = new DateTime(start.Year, start.Month, start.Day, value.Hours, value.Minutes, value.Seconds);
            }
        }

        public TimeSpan EndTime
        {
            get { return this.eventModel.End.DateTime.Value.TimeOfDay; }
            set
            {
                var end = this.eventModel.End.DateTime.Value;
                this.eventModel.End.DateTime = new DateTime(end.Year, end.Month, end.Day, value.Hours, value.Minutes, value.Seconds);
            }
        }

        private async void AddEvent()
        {
            var addedEvent = await this.googleApiService.PostAsync<Event, Event>("https://www.googleapis.com/calendar/v3/calendars/primary/events", this.eventModel);
        }
    }
}
