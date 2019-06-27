using System;
using System.Collections.Generic;
using System.Linq;

namespace p05.Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(" ").Where(x => x.Length % 2 == 0);

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
