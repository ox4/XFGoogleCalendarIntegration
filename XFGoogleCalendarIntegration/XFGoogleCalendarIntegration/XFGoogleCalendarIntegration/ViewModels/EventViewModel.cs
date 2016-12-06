using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFGoogleCalendarIntegration.Models.Calendar;

namespace XFGoogleCalendarIntegration.ViewModels
{
    public class EventViewModel : BaseViewModel
    {
        private Event eventModel;

        public EventViewModel(Event eventModel)
        {
            this.eventModel = eventModel;
        }

        public string Summary => this.eventModel.Summary;

        public string Period
        {
            get
            {
                return this.eventModel.Start.DateTime.Value.ToString("f") + " - " + this.eventModel.End.DateTime.Value.ToString("t");
            }
        }
    }
}
