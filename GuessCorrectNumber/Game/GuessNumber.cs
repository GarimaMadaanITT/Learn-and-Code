using GuessCorrectNumber.Constants;
using GuessCorrectNumber.Util;
using System;
using System.Security.Cryptography;

namespace GuessCorrectNumber.Game
{
    public class GuessNumber
    {
        private int secretNumber;
        private int guessCount;

        public void RunGame()
        {
            InitializeGame();
            Play();
        }

        private void InitializeGame()
        {
            secretNumber = RandomDataGenerator.Generate(GameSettings.MinimumNumber, GameSettings.MaximumNumber);
            guessCount = 0;
        }

        private void Play()
        {
            bool IsCorrectGuess = false;

            Console.WriteLine("Guess a number between 1 and 100:");

            while (!IsCorrectGuess)
            {
                int userGuess = InputReader.ReadInput();
                guessCount++;

                IsCorrectGuess = IsRightGuess(userGuess, secretNumber);

                if (IsCorrectGuess)
                {
                    Console.WriteLine($"You guessed it in {guessCount} guesses.");
                }
            }
        }

        private bool IsRightGuess(int userGuess, int secretNumber)
        {
            if (userGuess < secretNumber)
            {
                Console.WriteLine("Too low! Try again:");
                return false;
            }
            else if (userGuess > secretNumber)
            {
                Console.WriteLine("Too high! Try again:");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
