using GuessCorrectNumber.Constants;
using System;

namespace GuessCorrectNumber.Util
{
    public static class InputReader
    {
        public static int ReadInput()
        {
            while (true)
            {
                string userInput = Console.ReadLine();

                if (!IsValidNumber(userInput))
                {
                    Console.WriteLine("I won't count this one. Please enter a number between 1 and 100:");
                    continue;
                }

                return int.Parse(userInput);
            }
        }

        static bool IsValidNumber(string input)
        {
            return int.TryParse(input, out int number) && IsInRange(number);
        }

        static bool IsInRange(int number)
        {
            return number >= GameSettings.MinimumNumber && number <= GameSettings.MaximumNumber;
        }
    }
}
