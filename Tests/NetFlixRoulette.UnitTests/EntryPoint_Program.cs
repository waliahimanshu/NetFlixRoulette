using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace NetFlixRoulette.UnitTests
    {
    [TestFixture]
    class EntryPoint_Program
        {
        [Test]
        public void Test()
        {
            Program.Main(new []{"Me"});

        }
        }
    }
