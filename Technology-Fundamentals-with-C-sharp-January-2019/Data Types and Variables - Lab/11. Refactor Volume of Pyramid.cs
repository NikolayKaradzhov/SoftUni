using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideLenght = 0.0;
            double width = 0.0;
            double height = 0.0;

            double v = 0.0;

            Console.Write("Length: ");
            sideLenght = double.Parse(Console.ReadLine());

            Console.Write("Width: ");
            width = double.Parse(Console.ReadLine());

            Console.Write("Height: ");
            height = double.Parse(Console.ReadLine());

            v = (sideLenght * width * height) / 3;
            Console.WriteLine($"Pyramid Volume: {v:F2}");
        }
    }
}
