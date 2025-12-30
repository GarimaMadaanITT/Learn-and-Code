using System;

namespace GuessCorrectNumber.Util
{
    public static class RandomDataGenerator
    {
        private static readonly Random Random = new Random();

        public static int Generate(int min, int max)
        {
            return Random.Next(min, max + 1);
        }
    }
}
