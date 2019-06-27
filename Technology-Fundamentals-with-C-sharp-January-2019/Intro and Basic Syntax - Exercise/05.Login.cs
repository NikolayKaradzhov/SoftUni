using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string passwordInput = Console.ReadLine();

            string reversedInput = string.Empty;

            int counterWrongPasswords = 0;

            for (int i = passwordInput.Length - 1; i >= 0; i--)
            {
                reversedInput += passwordInput[i];
            }
            reversedInput.ToString();

            bool passwordIsFalse = true;

            while (passwordIsFalse)
            {
                string readPassword = Console.ReadLine();

                if (readPassword == reversedInput)
                {
                    Console.WriteLine($"User {passwordInput} logged in.");
                    break;
                }
                else if (readPassword != reversedInput)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                  
                    counterWrongPasswords++;
                }
                if (counterWrongPasswords > 2)
                {
                    Console.WriteLine($"User {passwordInput} blocked!");
                    break;
                }
            }

        }
    }
}
