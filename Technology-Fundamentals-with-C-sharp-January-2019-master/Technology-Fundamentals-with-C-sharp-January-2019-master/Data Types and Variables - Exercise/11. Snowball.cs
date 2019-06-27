using System;
using System.Numerics;

namespace p11.Snowball
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int snowballSnowMax = int.MinValue;
            int snowballTimeMax = int.MinValue;
            int snowballQualityMax = int.MinValue;
            BigInteger snowballValueMax = 0;

            for (int i = 0; i < n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                int product = (int)Math.Floor((decimal)snowballSnow / snowballTime);
                BigInteger snowballValue = BigInteger.Pow(product, snowballQuality);

                if (snowballValue > snowballValueMax)
                {
                    snowballValueMax = snowballValue;
                    snowballSnowMax = snowballSnow;
                    snowballTimeMax = snowballTime;
                    snowballQualityMax = snowballQuality;
                }
            }
            Console.WriteLine($"{snowballSnowMax} : {snowballTimeMax}" +
                $" = {snowballValueMax} ({snowballQualityMax})");
        }
    }
}
