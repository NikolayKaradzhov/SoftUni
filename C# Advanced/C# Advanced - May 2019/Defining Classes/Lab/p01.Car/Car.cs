using System;

namespace CarManufacturer
{
    class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsuption;

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }
        public string  Model
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
            return ($"Make: {this.Make}\nModel: {this.Model}\nYear: " +
                $"{this.Year}\nFuel: {this.FuelQuantity:F2}L");
        }
    }
}