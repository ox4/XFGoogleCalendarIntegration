using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFGoogleCalendarIntegration.Models.Calendar
{
    public class ListRequest
    {
        public DateTime? TimeMin { get; set; }

        public int? MaxResults { get; set; }
    }
}
