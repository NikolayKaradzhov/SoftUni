using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p05.Special_Cars_Extension_1_4_tasks_
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double distance = 20.0;
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> enginesList = new List<Engine>();
            List<Car> carsList = new List<Car>();

            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                string[] tires = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Tire[] allFourTires = new Tire[4]
                {
                    new Tire(int.Parse(tires[0]), double.Parse(tires[1])),
                    new Tire(int.Parse(tires[2]), double.Parse(tires[3])),
                    new Tire(int.Parse(tires[4]), double.Parse(tires[5])),
                    new Tire(int.Parse(tires[6]), double.Parse(tires[7])),
                };

                tiresList.Add(allFourTires);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Engines done")
            {
                string[] engines = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int horsepower = int.Parse(engines[0]);
                double cubicCapacity = double.Parse(engines[1]);

                Engine engine = new Engine(horsepower, cubicCapacity);

                enginesList.Add(engine);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Show special")
            {
                string[] cars = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string make = cars[0];
                string model = cars[1];
                int year = int.Parse(cars[2]);
                double fuelQantity = double.Parse(cars[3]);
                double fuelConsumption = double.Parse(cars[4]);
                int engineIndex = int.Parse(cars[5]);
                int tiresIndex = int.Parse(cars[6]);

                Car car = new Car(make, model, year, fuelQantity, fuelConsumption, enginesList[engineIndex], tiresList[tiresIndex]);

                bool tirePressureBetween9and10 = car.Tires.Select(x => x.Pressure).Sum() >= 9 
                    && car.Tires.Select(x => x.Pressure).Sum() <= 10;

                bool isCarSpecial = car.Year >= 2017 && car.Engine.HorsePower > 300 && tirePressureBetween9and10;

                if (isCarSpecial)
                {
                    car.Drive(distance);
                    carsList.Add(car);
                }

                input = Console.ReadLine();
            }

            foreach (var car in carsList)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }

    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsuption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.fuelConsuption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }
        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsuption; }
            set { this.fuelConsuption = value; }
        }

        public Engine Engine
        {
            get
            {
                return this.engine;
            }
            set
            {
                this.engine = value;
            }
        }

        public Tire[] Tires
        {
            get
            {
                return this.tires;
            }
            set
            {
                this.tires = value;
            }
        }

        public void Drive(double distance)
        {
            if (distance * this.FuelConsumption / 100 > this.FuelQuantity)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
            else
            {
                this.FuelQuantity -= this.FuelConsumption / 100 * distance;
            }
        }

        public string WhoAmI()
        {
            StringBuilder carInfo = new StringBuilder();

            carInfo.AppendLine($"Make: {this.Make}");
            carInfo.AppendLine($"Model: {this.Model}");
            carInfo.AppendLine($"Year: {this.Year}");
            carInfo.Append($"Fuel: {this.FuelQuantity:F2}L");

            return carInfo.ToString();
        }
    }

    class Engine
    {
        private int horsepower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower
        {
            get
            {
                return this.horsepower;
            }
            set
            {
                this.horsepower = value;
            }
        }

        public double CubicCapacity
        {
            get
            {
                return this.cubicCapacity;
            }
            set
            {
                this.cubicCapacity = value;
            }
        }
    }

    public class Tire
    {
        private int year;
        private double pressure;

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }

        public double Pressure
        {
            get
            {
                return this.pressure;
            }
            set
            {
                this.pressure = value;
            }
        }
    }
}