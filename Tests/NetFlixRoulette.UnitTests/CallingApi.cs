using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlixRoulette.UnitTests
{
    [TestFixture]
    public class CallingApi
    {
        [Test]
        public void Test()
        {
            var fakeClient = FakeHttpClient.Create();
            var proxy = new Proxy(fakeClient);

            var enumerable = proxy.GetResults("Nicolas Cage");

            Assert.That(enumerable,Is.Not.Empty);
        }
    }
}
