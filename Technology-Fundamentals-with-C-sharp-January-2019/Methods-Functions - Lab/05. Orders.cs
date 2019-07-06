using System;

namespace p05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string readProduct = Console.ReadLine();
            double quantity = int.Parse(Console.ReadLine());

            double result = CalculateTotalProductPrice(readProduct, quantity);
            Console.WriteLine($"{result:F2}");
        }

        private static double CalculateTotalProductPrice(string readProduct, double quantity)
        {
            double totalPrice = 0;

            if (readProduct == "coffee")
            {
                totalPrice = quantity * 1.50;
            }
            else if (readProduct == "water")
            {
                totalPrice = quantity * 1.0;
            }
            else if (readProduct == "coke")
            {
                totalPrice = quantity * 1.4;
            }
            else if (readProduct == "snacks")
            {
                totalPrice = quantity * 2.0;
            }
            return totalPrice;
        }
    }
}
