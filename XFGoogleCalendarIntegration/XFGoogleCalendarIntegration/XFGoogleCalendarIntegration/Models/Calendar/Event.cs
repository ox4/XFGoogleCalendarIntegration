using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XFGoogleCalendarIntegration.Models.Calendar
{
    public class Event
    {
        [JsonProperty("start")]
        public EventDateTime Start { get; set; }

        [JsonProperty("end")]
        public virtual EventDateTime End { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
