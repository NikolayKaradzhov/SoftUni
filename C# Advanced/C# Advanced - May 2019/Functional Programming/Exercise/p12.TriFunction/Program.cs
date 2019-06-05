using System;
using System.Linq;

namespace p12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split();

                /*Each name(string)
                 *  |
                    |  */  
            Func<string, int, bool> isLarger = (name, charsLenght)
                => name.Sum(x => x) >= charsLenght;
                   /* |
                      |
                  Get the sum of the ascii symbols in name(name.Sum)
                     */

            Func<string[], Func<string, int, bool>, string> nameFilter =
                (inputNames, isLargerFilter)
                => inputNames.FirstOrDefault(x => isLargerFilter(x, length));

            string resultName = nameFilter(names, isLarger);

            Console.WriteLine(resultName);
        }
    }
}