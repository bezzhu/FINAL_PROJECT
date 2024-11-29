using System;

namespace GuessTheNumberGame
{

    class GuessTheNumberGame
    {
        static void Main()
        {
            Console.WriteLine("Welcome to 'Guess the Number' game!");
            Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess it?");

            // რიცხვის გენერირება 1-დან 100-მდე
            Random random = new Random();
            int targetNumber = random.Next(1, 101);
            int attempts = 0;
            bool isGuessed = false;

            while (!isGuessed)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();
                int guessedNumber;

                // შეყვანის ვალიდაცია
                if (int.TryParse(input, out guessedNumber))
                {
                    if (guessedNumber < 1 || guessedNumber > 100)
                    {
                        Console.WriteLine("Please enter a number between 1 and 100.");
                        continue;
                    }

                    attempts++;

                    if (guessedNumber == targetNumber)
                    {
                        Console.WriteLine($"Congratulations! You guessed the number {targetNumber} in {attempts} attempts.");
                        isGuessed = true;
                    }
                    else if (guessedNumber < targetNumber)
                    {
                        Console.WriteLine("Too low! Try a higher number.");
                    }
                    else
                    {
                        Console.WriteLine("Too high! Try a lower number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }

}
