using System;

namespace p04.Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PasswordContainsSixToTenCharacters(input);
            PasswordConsistOnlyLettersAndDigits(input);
            PasswordHaveAtLeastTwoDigits(input);

            if (PasswordContainsSixToTenCharacters(input) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (PasswordConsistOnlyLettersAndDigits(input) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (PasswordHaveAtLeastTwoDigits(input) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if ((PasswordContainsSixToTenCharacters(input) == true) 
                && (PasswordConsistOnlyLettersAndDigits(input) == true) 
                && (PasswordHaveAtLeastTwoDigits(input) == true))
            {
                Console.WriteLine("Password is valid");
            }
        }
        private static bool PasswordContainsSixToTenCharacters(string input)

        {
            bool isCorrect = false;

            if (input.Length >= 6 && input.Length <= 10)
            {
                isCorrect = true;
            }
            else
            {
                isCorrect = false;
            }
            return isCorrect;
        }
        private static bool PasswordConsistOnlyLettersAndDigits(string input)
        {
            bool isCorrect = true;

            foreach (char c in input)
            {
                if ((c < 48 || c > 57) && (c < 65 || c > 90) && (c < 97 || c > 122))
                {
                    isCorrect = false;
                }
            }
            return isCorrect;
        }
        private static bool PasswordHaveAtLeastTwoDigits(string input)
        {
            bool isCorrect = false;
            int digitsCounter = 0;

            foreach (char c in input)
            {
                if (c > 47 && c < 58)
                {
                    digitsCounter++;
                }
            }
            if (digitsCounter > 1)
            {
                isCorrect = true;
            }
            else
            {
                isCorrect = false;
            }
            return isCorrect;
        }
    }
}
