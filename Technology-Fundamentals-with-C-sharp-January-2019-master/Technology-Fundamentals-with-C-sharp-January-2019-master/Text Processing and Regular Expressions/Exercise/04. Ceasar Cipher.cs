using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace p04.Ceasar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string encryptedWord = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(encryptedWord + (char)(input[i] + 3));
            }
            Console.WriteLine();
        }
    }
}
