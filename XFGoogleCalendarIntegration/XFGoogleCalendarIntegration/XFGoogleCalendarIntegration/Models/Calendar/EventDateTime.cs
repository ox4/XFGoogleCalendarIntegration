using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XFGoogleCalendarIntegration.Extensions;

namespace XFGoogleCalendarIntegration.Models.Calendar
{
   public class EventDateTime
    {
        [JsonIgnore]
        public DateTime? DateTime
        {
            get
            {
                return System.DateTime.Parse(this.DateTimeRaw);
            }
            set
            {
                if (value != null)
                {
                    this.DateTimeRaw = value.Value.ToRFC3339();
                }
            }
        } 

        [JsonProperty("dateTime")]
        public string DateTimeRaw { get; set; }
    }
}
