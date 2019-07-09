namespace CustomRandomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            RandomList randomList = new RandomList { "1", "2", "3", "4", "5", "432", "432423", "asd", "pesho" };
            Console.WriteLine(randomList.RandomString());
        }
    }
}