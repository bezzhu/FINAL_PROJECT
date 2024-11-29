using System;
using System.Collections.Generic;

namespace HangmanGame
{
     class HangmanGame
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Hangman!");

            // წინასწარ განსაზღვრული სიტყვების სია
            string[] wordList = { "apple", "banana", "grape", "orange", "peach", "cherry" };
            Random random = new Random();
            string targetWord = wordList[random.Next(wordList.Length)];

            // თამაშის ველები
            char[] guessedWord = new string('_', targetWord.Length).ToCharArray();
            HashSet<char> guessedLetters = new HashSet<char>();
            int attemptsLeft = 6; // მაქსიმალური მცდელობები

            while (attemptsLeft > 0 && new string(guessedWord) != targetWord)
            {
                Console.WriteLine($"\nWord: {new string(guessedWord)}");
                Console.WriteLine($"Attempts left: {attemptsLeft}");
                Console.Write("Guess a letter: ");
                string input = Console.ReadLine()?.ToLower();

                // ვალიდაციის შემოწმება
                if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Invalid input. Please enter a single letter.");
                    continue;
                }

                char guessedLetter = input[0];

                // დუბლირებული ასოს შემოწმება
                if (guessedLetters.Contains(guessedLetter))
                {
                    Console.WriteLine($"You already guessed '{guessedLetter}'. Try a different letter.");
                    continue;
                }

                guessedLetters.Add(guessedLetter);

                // სწორი/არასწორი ასოს დამუშავება
                if (targetWord.Contains(guessedLetter))
                {
                    Console.WriteLine($"Good job! The letter '{guessedLetter}' is in the word.");

                    for (int i = 0; i < targetWord.Length; i++)
                    {
                        if (targetWord[i] == guessedLetter)
                        {
                            guessedWord[i] = guessedLetter;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Sorry, the letter '{guessedLetter}' is not in the word.");
                    attemptsLeft--;
                }
            }

            // თამაშის დასასრული
            if (new string(guessedWord) == targetWord)
            {
                Console.WriteLine($"\nCongratulations! You guessed the word: {targetWord}");
            }
            else
            {
                Console.WriteLine($"\nGame over! The word was: {targetWord}");
            }
        }
    }
}
