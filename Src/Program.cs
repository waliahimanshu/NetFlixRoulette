using System;

namespace NetFlixRoulette
    {
    public static class Program
        {
        public static void Main(string[] args)
            {
            var input = Console.ReadLine();

            if (input == null || string.IsNullOrWhiteSpace(input))
                {
                throw new InvalidOperationException("Provide at least one parameter");
                }
            ContainerFactory.Create(input);
            }
        }
    }
