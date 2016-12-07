using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XFGoogleCalendarIntegration.Constants
{
    public static class GoogleApiConstants
    {
        // Client Id Web Application проекта 
        public static string ClientId = "";

        // Client Secret Web Application проекта 
        public static string ClientSecret = "";

        // Redirect URL Web Application проекта 
        public static string RedirectUrl = "";

        // Scope запрашиваемой части API
        public static string Scope = "https://www.googleapis.com/auth/calendar";


        public static string CalendarListRequestUrl =
            "https://www.googleapis.com/calendar/v3/calendars/{calendarId}/events";

        public static string AddEventRequestUrl = "https://www.googleapis.com/calendar/v3/calendars/{calendarId}/events";

        public static string MainCalendarId = "primary";
    }
}
