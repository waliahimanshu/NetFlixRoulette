using System;

namespace NetFlixRoulette
{
    public  class ConsoleUser : IConsoleUser
    {
        public  string TakeInput()
        {
            Console.WriteLine("Enter Actor's name");

            var name = Console.ReadLine();

            Console.WriteLine("Looking for random movies by :" + name);

            return name;
        }
    }
}