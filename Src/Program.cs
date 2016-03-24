using System;
using System.Linq;
using Autofac;
using Autofac.Core.Lifetime;
using NetFlixRoulette.Contract;

namespace NetFlixRoulette
    {
    public static class Program
        {

        public static void Main(string[] args)
            {
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                {
                throw new InvalidOperationException("Provide at least one parameter");
                }

            var container = ContainerFactory.Create(input);

            var proxy = container.Resolve<Proxy>();

            var orchestrator = new Orchestrator(proxy);

            orchestrator.Orchestrate();
           }
        }
    }
