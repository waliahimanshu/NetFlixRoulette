using System;
using System.IO;
using NUnit.Framework;

namespace NetFlixRoulette.UnitTests
    {
    [TestFixture]
    class EntryPointProgramTests
        {
       

        [Test]
        public void Test_valid_console_input()
        {
            var input = "Nicolas Cage"+Environment.NewLine;
            var first = $"Enter Actor's name{Environment.NewLine}";
            var second = "Looking for random movies by :" + input;

            using (var stringWriter = new StringWriter())
            {
                System.Console.SetOut(stringWriter);
                using (var stringReader = new StringReader(input))
                {
                    System.Console.SetIn(stringReader);

                    var consoleUser= new ConsoleUser ();
                    consoleUser.TakeInput();

                    Assert.That(stringWriter.ToString(), Is.EqualTo(first+second));
                }
            }
        }

        [TestCase("")]
        [TestCase(" ")]
        public void Validate_invalid_input(string name)
        {
            var exception = Assert.Throws<InvalidOperationException>(
                
                () => new Validator().Validate(""));

            Assert.That(exception.Message,Is.EqualTo("Provide a valid name"));
        }

        [Test]
        public void valid_input()
        {
           Assert.DoesNotThrow(() => new Validator().Validate("MyName"));
        }


        [TearDown]
        public void AfterTest()
        {
           var standardOutPut = new StreamWriter(System.Console.OpenStandardOutput()) {AutoFlush = true};
            System.Console.SetOut(standardOutPut);
        }
        }
    }
