using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XFGoogleCalendarIntegration.Models.Calendar
{
   public class EventDateTime
    {
        [JsonIgnore]
        public DateTime? DateTime => System.DateTime.Parse(this.DateTimeRaw);

        [JsonProperty("dateTime")]
        public string DateTimeRaw { get; set; }
    }
}
