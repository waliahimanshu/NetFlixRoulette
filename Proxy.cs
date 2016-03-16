using System;
using System.Collections.Generic;

namespace NetFlixRoulette
{
    internal class Proxy : IProxy
    {
        private MySettings settigs;

        public Proxy(MySettings settigs)
        {
            this.settigs = settigs;
        }

        public IEnumerable<dynamic> GetResults(string actorsName)
        {
            throw new NotImplementedException();
        }
    }
}