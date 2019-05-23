using System;
using System.Collections.Generic;

namespace p06.Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingInfo = new HashSet<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string carLicensePlate = tokens[1];

                if (command == "IN")
                {
                    parkingInfo.Add(carLicensePlate);
                }
                else if (command == "OUT")
                {
                    parkingInfo.Remove(carLicensePlate);
                }

                input = Console.ReadLine();
            }

            foreach (var carNumber in parkingInfo)
            {
                Console.WriteLine(carNumber);
            }
        }
    }
}