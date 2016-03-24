using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using NetFlixRoulette.Contract;
using Newtonsoft.Json;

namespace NetFlixRoulette
    {
    public class Proxy : IProxy
        {
        private readonly MySettings _settings;
        private readonly HttpClient _httpClient;

        public Proxy(MySettings settings, HttpClient httpClient)
            {
            _settings = settings;
            _httpClient = httpClient;
            }

        public IEnumerable<ResponseObject> GetResults()
            {
            var httpRequestMessage = CreateRequest();

            var responseMessage = _httpClient.SendAsync(httpRequestMessage);

            string httpResponseMessage = null;

            if (responseMessage.Result.IsSuccessStatusCode)
                {
                httpResponseMessage = responseMessage.Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(httpResponseMessage);
                }
            else
                {
                httpResponseMessage = responseMessage.Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(JsonConvert.DeserializeObject(httpResponseMessage));
                return Enumerable.Empty<ResponseObject>();
            }
            return GetResponse(httpResponseMessage);
            }

        private static IEnumerable<ResponseObject> GetResponse(string httpResponseMessage)
            {
            return JsonConvert.DeserializeObject<IEnumerable<ResponseObject>>(httpResponseMessage);
            }

        private HttpRequestMessage CreateRequest()
            {
            var path = $"?actor={_settings.ActorName}";

            var httpRequestMessage = new HttpRequestMessage
                {
                RequestUri = new Uri(path, UriKind.Relative),
                Method = HttpMethod.Get,
                Headers = { { "X-Mashape-Key", "ux17bI21Xgmshjzt2fXJMih7IiWkp1zjYxBjsnxRny7GbaToXc" }, { "Accept", "application/json" } }
                };
            return httpRequestMessage;
            }
        }
    }