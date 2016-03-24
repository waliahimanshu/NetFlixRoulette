using System.Collections.Generic;
using NetFlixRoulette.Contract;

namespace NetFlixRoulette
{
    public interface IProxy
    {
       IEnumerable<ResponseObject> GetResults();
    }
}