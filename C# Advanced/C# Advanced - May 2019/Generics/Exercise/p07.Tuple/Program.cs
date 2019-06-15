using System;

namespace p07.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split();

            string[] personBeerInfo = Console.ReadLine()
                .Split();

            string[] numbersInfo = Console.ReadLine()
                .Split();

            //personInfo
            string personName = personInfo[0] + " " + personInfo[1];
            string city = personInfo[2];

            //personBeerInfo
            string name = personBeerInfo[0];
            int litersBeer = int.Parse(personBeerInfo[1]);

            //numberInfo
            int firstNumber = int.Parse(numbersInfo[0]);
            double secondNumber = double.Parse(numbersInfo[1]);

            Tuple<string, string> person = new Tuple<string, string>(personName, city);
            Tuple<string, int> beer = new Tuple<string, int>(name, litersBeer);
            Tuple<int, double> someNumbers = new Tuple<int, double>(firstNumber, secondNumber);

            string personResult = person.Print();
            string beerResult = beer.Print();
            string someNumbersResult = someNumbers.Print();

            Console.WriteLine(personResult);
            Console.WriteLine(beerResult);
            Console.WriteLine(someNumbersResult);
        }
    }
}