using Autofac;

namespace NetFlixRoulette
    {
    public static class ContainerFactory
        {
        public static void Create(string input)
            {
            var builder = new ContainerBuilder();
            var mySettings = new MySettings
            {
                ActorName = input
            };

            builder.RegisterInstance(mySettings);
            builder.RegisterModule<ProxyModule>();
            builder.Build();
            }
        }
    }