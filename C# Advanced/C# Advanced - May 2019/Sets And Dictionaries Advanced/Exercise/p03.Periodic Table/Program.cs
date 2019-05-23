using System;
using System.Collections.Generic;
using System.Linq;

namespace p03.Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> chemicalCompounds = new HashSet<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] chemicals = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < chemicals.Length; j++)
                {
                    chemicalCompounds.Add(chemicals[j]);
                }
            }

            var orderedChemicals = chemicalCompounds.OrderBy(x => x);

            foreach (var chemical in orderedChemicals)
            {
                Console.Write($"{chemical} ");
            }
        }
    }
}
