using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XFGoogleCalendarIntegration.Extensions;
using XFGoogleCalendarIntegration.Models;

namespace XFGoogleCalendarIntegration.Services
{
    public class GoogleApiService
    {
        private readonly HttpClient httpClient;

        public GoogleApiService(AccessTokenModel token)
        {
            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Add("Authorization", token.TokenType + " " + token.AccessToken);
        }

        public async Task<TResponse> GetAsync<TRequest, TResponse>(string url, TRequest request,
            IDictionary<string, string> parameters = null)
            where TRequest : class
            where TResponse : class
        {
            var requestUrl = parameters == null ? url : url.InjectParameters(parameters);
            var queryString = request == null ? string.Empty : request.ToQueryString();
            requestUrl += queryString;

            var response = await httpClient.GetAsync(requestUrl);
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request,
            IDictionary<string, string> parameters = null)
        {
            var requestUrl = parameters == null ? url : url.InjectParameters(parameters);
            var requestBody = request == null ? string.Empty : JsonConvert.SerializeObject(request);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUrl)
            {
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            var response = await this.httpClient.SendAsync(requestMessage);
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
    }
}
