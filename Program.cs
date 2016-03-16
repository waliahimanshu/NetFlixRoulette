using System;
using System.Linq;

namespace NetFlixRoulette
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args == null || string.IsNullOrWhiteSpace(args.First()))
            {
                throw new InvalidOperationException("Provide at least one paramater");
            }

            var settigs = new MySettings
                {
                    ActorName = args.First()
                };

            new Proxy(settigs);
        }
    }
}
