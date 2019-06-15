using System;

namespace p08.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfoInput = Console.ReadLine()
                .Split();

            string name = personInfoInput[0] + " " + personInfoInput[1];
            string address = personInfoInput[2];
            string town = personInfoInput[3];

            Threeuple<string, string, string> personInfo = new Threeuple<string, string, string>(name, address, town);

            string[] beerInfoInput = Console.ReadLine()
                .Split();

            string nameBeer = beerInfoInput[0];
            int litersOfBeer = int.Parse(beerInfoInput[1]);
            string drunkOrNot = beerInfoInput[2];

            bool isDrunk = false;

            if (drunkOrNot == "drunk")
            {
                isDrunk = true;
            }
            else
            {
                isDrunk = false;
            }

            Threeuple<string, int, bool> beerInfo = new Threeuple<string, int, bool>(nameBeer, litersOfBeer, isDrunk);

            string[] bankInfoInput = Console.ReadLine()
                .Split();

            string bankAccountName = bankInfoInput[0];
            double accountBalance = double.Parse(bankInfoInput[1]);
            string bankName = bankInfoInput[2];

            Threeuple<string, double, string> bankInfo = new Threeuple<string, double, string>(bankAccountName, accountBalance, bankName);

            Console.WriteLine(personInfo.Print());
            Console.WriteLine(beerInfo.Print());
            Console.WriteLine(bankInfo.Print());
        }
    }
}