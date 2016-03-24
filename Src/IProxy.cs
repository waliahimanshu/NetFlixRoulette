using System.Collections.Generic;
using System.Threading.Tasks;
using NetFlixRoulette.Contract;

namespace NetFlixRoulette
{
    internal interface IProxy
    {
       IEnumerable<ResponseObject> GetResults();
    }
}