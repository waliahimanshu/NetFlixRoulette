using Autofac;
using Topshelf;

namespace NetFlixRoulette
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //            var name = TakeInput();
            //            new Validator().Validate(name);
            //            IApplication orchestrator = new Application();
            //            orchestrator.Run(name);
            //            Console.ReadLine();

            var container = ContainerFactory.Create();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                var name = app.Run();
                app.GetResultFor(name);
            }
        }

        private static IContainer IntializeContainer()
        {
            var container = ContainerFactory.Create();
            return container;
        }

        

        private static void TopShelf()
        {
            HostFactory.Run(x =>
            {
                x.Service<Roullete>(y =>
                {
                    y.ConstructUsing(name => new Roullete());
                    y.WhenStarted(r => r.Start());
                    y.WhenStopped(r => r.Stop());
                });
                x.SetServiceName("Roullete api");
                x.AddCommandLineDefinition("Actor Name", s => { });
            });
        }
    }
}
