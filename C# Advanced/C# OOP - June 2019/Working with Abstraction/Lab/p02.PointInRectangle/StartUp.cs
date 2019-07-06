using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.PointInRectangle
{
    public class StartUp
    {
        public static void Main()
        {
            List<double> coordinates = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            double topLeftX = coordinates[0];
            double topLeftY = coordinates[1];
            double bottomRightX = coordinates[2];
            double bottomRightY = coordinates[3];

            int linesCount = int.Parse(Console.ReadLine());

            Rectangle rectangle = new Rectangle(new Point(topLeftX, topLeftY), new Point(bottomRightX, bottomRightY));

            for (int i = 0; i < linesCount; i++)
            {
                List<double> pointCoordinates = Console.ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToList();

                double pointX = pointCoordinates[0];
                double pointY = pointCoordinates[1];

                Point point = new Point(pointX, pointY);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
