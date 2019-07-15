namespace ClassBoxData
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():F2}");

                Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurfaceArea():F2}");

                Console.WriteLine($"Volume - {box.CalculateVolume():F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}