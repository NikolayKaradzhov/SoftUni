using System;

namespace p08.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double biggerKeg = 0.0;
            string biggestKeg = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string modelKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double radiusPowered = (double)Math.Pow(radius, 2);

                double result = ((Math.PI * Math.Pow(radius, 2)) * height);

                if (result >= biggerKeg)
                {
                    biggerKeg = result;
                    biggestKeg = modelKeg;
                }
            }
            Console.WriteLine($"{biggestKeg}");
        }
    }
}
