using System;

namespace FourDigits
{
    class Game
    {
        static void Main(string[] args)
        {
 
            string secretNumber = GenerateSecretNumber();
            string tryGuess = "";
            int countGuesses = 0;
            int guessLimit = 8;
            bool guessLimitReached = false;

            Console.WriteLine("You have to guess the 4-digit secret number in 8 tries! Digits don't repeat!");
            Console.WriteLine("M - number of matching digits which are not in the right place");
            Console.WriteLine("P - number of matching digits in the right place");

            while (tryGuess != secretNumber && !guessLimitReached)
            {
                if (countGuesses < guessLimit)
                {
       
                    Console.Write($"{countGuesses + 1}. try: ");
                    tryGuess = Console.ReadLine();

                    // Check if user entered valid 4-digit number
                    if (checkValidGuess(tryGuess))
                    {
                        // Check guessed digits after each try
                        int mDigitsNotInPlace = CalculatemDigitsNotInPlace(secretNumber, tryGuess);
                        int mDigitsInPlace = CalculatemDigitsInPlace(secretNumber, tryGuess);

                        Console.WriteLine($"M:{mDigitsNotInPlace}; P:{mDigitsInPlace}");
                        countGuesses++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    guessLimitReached = true;
                }
            }

            if (guessLimitReached)
            {
                Console.WriteLine($"Game over! The secret number was: {secretNumber}");
            }
            else
            {
                Console.WriteLine($"Correct! You guessed the number: {secretNumber}!");
            }
        }

        static string GenerateSecretNumber() // Creating a random number
        {
            Random random = new Random();
            string secretNumber = "";

            while (secretNumber.Length < 4) // Generate 4 different digits
            {
                int digit = random.Next(0, 10);
                if (!secretNumber.Contains(digit.ToString())) // to check if the generated digit hasn't been generated already
                {
                    secretNumber += digit;
                }
            }

            return secretNumber;
        }

        static bool checkValidGuess(string guess) // Check if user entered a valid 4-digit number
        {
            if (guess.Length != 4)
            {
                return false;
            }

            for (int i = 0; i < guess.Length; i++)
            {
                if (!char.IsDigit(guess[i])) // if user enters anything else except a digit, it will return false
                {
                    return false;
                }

                for (int j = i + 1; j < guess.Length; j++)
                {
                    if (guess[i] == guess[j]) //if user enters a digit he already entered, it will return false
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static int CalculatemDigitsNotInPlace(string secret, string guess) // to check m - number of matching digits which are not on the right place
        {
            int mDigitsNotInPlace = 0;

            for (int i = 0; i < secret.Length; i++)
            {
                if (secret.Contains(guess[i]) && secret[i] != guess[i])
                {
                    mDigitsNotInPlace++;
                }
            }
            return mDigitsNotInPlace;
        }

        static int CalculatemDigitsInPlace(string secret, string guess) //to check p - number of matching digits in the right place
        {
            int mDigitsInPlace = 0;

            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    mDigitsInPlace++;
                }
            }

            return mDigitsInPlace;
        }
    }
}
