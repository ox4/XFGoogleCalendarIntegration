using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFGoogleCalendarIntegration.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToRFC3339(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-ddTHH:mm:ssK");
        }
    }
}
