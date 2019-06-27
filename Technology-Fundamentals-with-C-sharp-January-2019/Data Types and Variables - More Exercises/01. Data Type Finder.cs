using System;

namespace p01.Data_Type_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int inputIsInteger;
            float inputIsFloating;
            char inputIsChar;
            bool inputIsBool;
            
            while (input != "END")
            {
                if (int.TryParse(input, out inputIsInteger))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (float.TryParse(input, out inputIsFloating))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (char.TryParse(input, out inputIsChar))
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (bool.TryParse(input, out inputIsBool))
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }

                input = Console.ReadLine();
            }
        }
    }
}
