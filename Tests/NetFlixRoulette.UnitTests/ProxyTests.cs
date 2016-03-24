using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace NetFlixRoulette.UnitTests
    {
    [TestFixture]
    public class ProxyTests
        {
        private FakeHttpClient _fakeHttpClient;
        private IEnumerable<TestResponse> _testResponse;
        private MySettings _mySettings;

        [SetUp]
        public void Setup()
            {
            _testResponse = new Fixture().Create<IEnumerable<TestResponse>>();
            _fakeHttpClient = FakeHttpClient.Create();
            _mySettings = new MySettings { ActorName = "Me" };
            }

        [Test]
        public void Should_return_200_ok_when_success()
            {
            SetupSuccessResponseFor(HttpStatusCode.OK, _testResponse);

            var poxy = new Proxy(_mySettings, _fakeHttpClient);

            var enumerable = poxy.GetResults();

            Assert.That(enumerable.Count(), Is.GreaterThan(0));
            }


        [Test]
        public void Should_return_500_in_case_of_exception()
            {
            SetupSuccessResponseFor(HttpStatusCode.InternalServerError, null);

            var poxy = new Proxy(_mySettings, _fakeHttpClient);

            Assert.That(() => poxy.GetResults(), Throws.Exception.InstanceOf<HttpRequestException>());

            }

        [Test]
        public void check_when_invalid_response_returned()
            {
            SetupSuccessResponseFor(HttpStatusCode.OK,null);

            var poxy = new Proxy(_mySettings, _fakeHttpClient);

            Assert.That(() => poxy.GetResults(), Throws.Exception.InstanceOf<HttpRequestException>());

            }

        private void SetupSuccessResponseFor(HttpStatusCode statusCode, IEnumerable<TestResponse> responseMessage)
            {
            var uriString = $"?actor={_mySettings.ActorName}";
            var httpResponseMessage = new HttpResponseMessage
                {
                StatusCode = statusCode,
                Content = new ObjectContent<IEnumerable<TestResponse>>(responseMessage, new JsonMediaTypeFormatter()),
                RequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(uriString))
                };

            _fakeHttpClient.AddResponse(httpResponseMessage);
            }
        }
    }
