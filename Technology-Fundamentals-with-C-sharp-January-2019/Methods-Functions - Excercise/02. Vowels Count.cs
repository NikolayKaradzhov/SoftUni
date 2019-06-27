using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p02.Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

          int result = VowelCounter(input);

            Console.WriteLine(result);
        }

        private static int VowelCounter(string input)
        {
            string[] read = new string[input.Length];

            int vowelCount = 0;

            for (int i = 0; i < read.Length; i++)
            {
                read[i] = input[i].ToString();

                if (read[i] == "a" || read[i] == "A")
                {
                    vowelCount++;
                }
                else if (read[i] == "e" || read[i] == "E")
                {
                    vowelCount++;
                }
                else if (read[i] == "i" || read[i] == "I")
                {
                    vowelCount++;
                }
                else if (read[i] == "o" || read[i] == "O")
                {
                    vowelCount++;
                }
                else if (read[i] == "u" || read[i] == "U")
                {
                    vowelCount++;
                }
            }
            return vowelCount;
        }
    }
}
