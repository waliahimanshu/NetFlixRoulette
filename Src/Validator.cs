using System;

namespace NetFlixRoulette
{
    public class Validator : IValidator
    {
        public void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidOperationException("Provide a valid name");
            }

        }
    }
}