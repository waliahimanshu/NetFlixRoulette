using System.Collections.Generic;

namespace NetFlixRoulette
{
    internal interface IProxy
    {
        IEnumerable<dynamic> GetResults(string actorsName);
    }
}