using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using XFGoogleCalendarIntegration.Constants;
using XFGoogleCalendarIntegration.Models;

namespace XFGoogleCalendarIntegration.Services
{
    public class GoogleOAuthService
    {
        private readonly HttpClient httpClient;

        public GoogleOAuthService()
        {
            this.httpClient = new HttpClient();
        }

        public string RequestUrl => "https://accounts.google.com/o/oauth2/v2/auth"
                                    + "?response_type=code"
                                    + "&scope=" + GoogleApiConstants.Scope
                                    + "&redirect_uri=" + GoogleApiConstants.RedirectUrl
                                    + "&client_id=" + GoogleApiConstants.ClientId;

        public string ExtractCodeFromUrl(string url)
        {
            if (url.Contains("code="))
            {
                var attributes = url.Split('&');
                var code = attributes.FirstOrDefault(s => s.Contains("code=")).Split('=')[1];
                return code;
            }

            return string.Empty;
        }

        public async Task<AccessTokenModel> GetAccessTokenAsync(string code)
        {
            var stringRequest = "code=" + code
                + "&client_id=" + GoogleApiConstants.ClientId
                + "&client_secret=" + GoogleApiConstants.ClientSecret
                + "&grant_type=authorization_code"
                + "&redirect_uri=" + GoogleApiConstants.RedirectUrl;

            var requestUrl = "https://www.googleapis.com/oauth2/v4/token";

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            request.Content = new StringContent(stringRequest,
                                                Encoding.UTF8,
                                                "application/x-www-form-urlencoded");

            var response = await httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AccessTokenModel>(responseContent);
        }
    }
}
