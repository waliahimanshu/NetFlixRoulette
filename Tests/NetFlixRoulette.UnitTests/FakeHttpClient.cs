using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NetFlixRoulette.UnitTests
    {
    public class FakeHttpClient : HttpClient
        {
        private FakeHttpMessageHandler _httpMessageHandler;

        private FakeHttpClient(Uri uri,FakeHttpMessageHandler fakeHttpMessageHandler) : base(fakeHttpMessageHandler)
            {
            _httpMessageHandler = fakeHttpMessageHandler;
            }


        private FakeHttpClient(FakeHttpMessageHandler handler) : this(null, handler)
            {
            }
        public static FakeHttpClient Create()
        {
            var fakeHttpClient = new FakeHttpClient(new FakeHttpMessageHandler());
            fakeHttpClient.BaseAddress = new Uri("https://community-netflix-roulette.p.mashape.com/api.php");
            return fakeHttpClient;
        }

        public void AddResponse(HttpResponseMessage httpResponseMessage)
            {
            _httpMessageHandler.AddResponse(httpResponseMessage);
            }
        }

        public class FakeHttpMessageHandler : HttpMessageHandler
        {
        private HttpResponseMessage _httpResponseMessage;


        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {

            var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletionSource.SetResult(_httpResponseMessage);
            return taskCompletionSource.Task;
            }

        public void AddResponse(HttpResponseMessage httpResponseMessage)
            {
            _httpResponseMessage = httpResponseMessage;
            }
        }
    }