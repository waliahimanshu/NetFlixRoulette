using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace NetFlixRoulette.UnitTests
    {
    [TestFixture]
    public class ProxyTests
        {
        private FakeHttpClient _fakeHttpClient;
        private IEnumerable<TestResponse> _testResponse;

        [SetUp]
        public void Setup()
            {
            _testResponse = new Fixture().Create<IEnumerable<TestResponse>>();
            _fakeHttpClient = FakeHttpClient.Create();
            }

        [Test]
        public void Should_return_200_ok_when_success()
            {
            SetupResponseFor(HttpStatusCode.OK, _testResponse);

            var poxy = new Proxy(_fakeHttpClient);

            var responseObjects = poxy.GetResults("Some Name");

            Assert.That(responseObjects.Count(), Is.GreaterThan(0));
            }


        [Test]
        public void Should_return_empty_object_when_500()
            {
            SetupResponseFor(HttpStatusCode.InternalServerError, null);

            var poxy = new Proxy(_fakeHttpClient);
            var responseObjects = poxy.GetResults("Some Name");

            Assert.That(responseObjects.Count(),Is.Zero);
            }

      

        private void SetupResponseFor(HttpStatusCode statusCode, IEnumerable<TestResponse> responseMessage)
            {
            var uriString = $"?actor={"some name"}";
            var httpResponseMessage = new HttpResponseMessage
                {
                StatusCode = statusCode,
                Content = new ObjectContent<IEnumerable<TestResponse>>(responseMessage, new JsonMediaTypeFormatter()),
                RequestMessage = new HttpRequestMessage(HttpMethod.Get, new Uri(uriString,UriKind.Relative))
                };

            _fakeHttpClient.AddResponse(httpResponseMessage);
            }
        }
    }
