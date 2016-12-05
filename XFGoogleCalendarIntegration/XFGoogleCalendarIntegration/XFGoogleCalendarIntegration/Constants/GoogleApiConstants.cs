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
        public static string ClientId = "97528569723-gjoi1v41kct2eb552qhf5s3333jvfs59.apps.googleusercontent.com";

        // Client Secret Web Application проекта 
        public static string ClientSecret = "BGn6iEJVRv5Zh9saTn0ij49r";

        // Redirect URL Web Application проекта 
        public static string RedirectUrl = "https://plus.google.com/";

        // Scope запрашиваемой части API
        public static string Scope = "https://www.googleapis.com/auth/calendar";
    }
}
