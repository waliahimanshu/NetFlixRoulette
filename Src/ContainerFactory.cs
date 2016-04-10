using Autofac;

namespace NetFlixRoulette
    {
    public static class ContainerFactory
        {
        public static IContainer Create()
            {
            var builder = new ContainerBuilder();
            
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ILifetimeScope>().As<ILifetimeScope>();
            builder.RegisterType<Proxy>().As<IProxy>();
            
            builder.RegisterModule<ProxyModule>();
           return builder.Build();
            }
        }
    }