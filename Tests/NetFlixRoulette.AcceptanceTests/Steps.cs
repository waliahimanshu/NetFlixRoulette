using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace NetFlixRoulette.AcceptanceTests
{
    [Binding]
    public class Steps
    {
        [Given(@"A user running the command line application")]
        public void GivenAUserRunningTheCommandLineApplication()
        {
            Program.Main(new string[] { "" });
        }
        [Given(@"I can supply a valid paramter on the command line")]
        public void GivenICanSupplyAValidParamterOnTheCommandLine()
        {
            ScenarioContext.Current.Pending();
        }
        [When(@"I hit return")]
        public void WhenIHitReturn()
        {
            ScenarioContext.Current.Pending();
        }
        [Then(@"I can query the API for results")]
        public void ThenICanQueryTheApiForResults()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
