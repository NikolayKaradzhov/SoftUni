using System;

namespace p05.Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            int charactersCount = int.Parse(Console.ReadLine());

            char letter;
            char output;
            string endResult = "";

            for (int i = 0; i < charactersCount; i++)
            {
                 letter = char.Parse(Console.ReadLine());
                 output = Convert.ToChar(letter + key);
                 endResult += Convert.ToString(output);

            }
                Console.WriteLine(endResult);
        }
    }
}
