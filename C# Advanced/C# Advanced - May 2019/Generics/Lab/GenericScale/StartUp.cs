using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var scale = new EqualityScale<string>("5", "5");
            Console.WriteLine(scale.AreEqual());
        }
    }
}