using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using XFGoogleCalendarIntegration.Constants;
using XFGoogleCalendarIntegration.Models;

namespace XFGoogleCalendarIntegration.Services
{
    public class GoogleCalendarService
    {
        static string ApplicationName = "CalendarTest";

        private readonly CalendarService calendarService;

        public GoogleCalendarService(AccessTokenModel token)
        {
            var tokenResponse = new TokenResponse()
            {
                AccessToken = token.AccessToken,
                TokenType = "Bearer",
                ExpiresInSeconds = 3600,
                //RefreshToken = "1/ncSo0qPftogkBpA3vLRqOsh_7iWBjtxrQevKQ-bLdH0",
                Issued = DateTime.Now
            };

            var credential = this.Authorize(tokenResponse);
            this.calendarService = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public IEnumerable<Event> GetUpcomingEvents()
        {
            var request = this.calendarService.Events.List("primary");
            request.TimeMin = DateTime.Now.AddDays(-60);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            var events = request.Execute();
            return events.Items;
        }

        private UserCredential Authorize(TokenResponse tokenResponse)
        {
            var credentials = new UserCredential(new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets()
                    {
                        ClientId = GoogleApiConstants.ClientId,
                        ClientSecret = GoogleApiConstants.ClientSecret
                    },
                    Scopes = new List<string> { CalendarService.Scope.CalendarReadonly },
                }),
                "user",
                tokenResponse);
            return credentials;
        }
    }
}
