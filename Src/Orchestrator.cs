using System.Collections.Generic;
using NetFlixRoulette.Contract;

namespace NetFlixRoulette
{
    public class Orchestrator
    {
        private readonly IProxy _proxy;

        public Orchestrator(IProxy proxy)
        {
            _proxy = proxy;

        }

        public void Orchestrate()
        {
             _proxy.GetResults();
        }
    }
}