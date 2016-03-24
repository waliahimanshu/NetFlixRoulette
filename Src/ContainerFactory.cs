using Autofac;

namespace NetFlixRoulette
    {
    public static class ContainerFactory
        {
        public static IContainer Create(string input)
            {
            var builder = new ContainerBuilder();
            var mySettings = new MySettings
            {
                ActorName = input
            };
            builder.RegisterType<ILifetimeScope>().As<ILifetimeScope>();
            builder.RegisterInstance(mySettings);
            builder.RegisterType<Proxy>();
            
            builder.RegisterModule<ProxyModule>();
           return builder.Build();
            }
        }
    }