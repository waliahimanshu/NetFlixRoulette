using Moq;
using NUnit.Framework;

namespace NetFlixRoulette.UnitTests
{
    [TestFixture]
   public class OrchestratorTests
    {

        [Test]
        public void calls_get_result()
        {
            var proxyMock = new Mock<IProxy>();
            var validateMock = new Mock<IValidator>();
            var consoleUserMock = new Mock<IConsoleUser>();

            var orchestrator = new Application(proxyMock.Object,validateMock.Object, consoleUserMock.Object);

            var name = "Some Name";
            orchestrator.GetResultFor(name);

            proxyMock.Verify(x=>x.GetResults(name),Times.Once);
        }

        [Test]
        public void calls_run()
        {
            var proxyMock = new Mock<IProxy>();
            var validateMock = new Mock<IValidator>();
            var consoleUserMock = new Mock<IConsoleUser>();

            var orchestrator = new Application(proxyMock.Object, validateMock.Object,consoleUserMock.Object);

            var name = "Some Name";
            consoleUserMock.Setup(x => x.TakeInput()).Returns("The Rock Dwane");
            validateMock.Setup(x => x.Validate("The Rock Dwane"));

            orchestrator.Run();

            validateMock.Verify(x=>x.Validate("The Rock Dwane"),Times.Once);
            consoleUserMock.Verify(x=>x.TakeInput(),Times.Once);
        }
    }
}
