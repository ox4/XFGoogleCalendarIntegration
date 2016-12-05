using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XFGoogleCalendarIntegration.Models.Calendar
{
    public class Events
    {
        [JsonProperty("items")]
        public IList<Event> Items { get; set; }
    }
}
