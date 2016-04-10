namespace NetFlixRoulette
{
    public class Application : IApplication
    {
        private readonly IProxy _proxy;
        private readonly IValidator _validator;
        private readonly IConsoleUser _consoleUser;

        public Application(IProxy proxy, IValidator validator, IConsoleUser consoleUser)
        {
            _proxy = proxy;
            _validator = validator;
            _consoleUser = consoleUser;
        }

        public string Run()
        {
            var name =_consoleUser.TakeInput();
            _validator.Validate(name);
            return name;
        }

        public void GetResultFor(string name)
        {
            _proxy.GetResults(name);
        }
    }
}