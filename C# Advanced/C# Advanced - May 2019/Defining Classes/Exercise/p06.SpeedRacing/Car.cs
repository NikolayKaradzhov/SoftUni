using System;
using System.Collections.Generic;
using System.Text;

namespace p06.SpeedRacing
{
    class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerkKilometer;
        private double travelledDistance;
        private List<Car> carList;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public double FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }
            set
            {
                this.fuelAmount = value;
            }
        }

        public double FuelConsumptionPerKilometer
        {
            get
            {
                return this.fuelConsumptionPerkKilometer;
            }
            set
            {
                this.fuelConsumptionPerkKilometer = value;
            }
        }

        public double TravelledDistance
        {
            get
            {
                return this.travelledDistance;
            }
            set
            {
                this.travelledDistance = value;
            }
        }
        public double Distance { get; set; }

        public void Drive(double distance)
        {
            if (fuelConsumptionPerkKilometer * distance > fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= FuelConsumptionPerKilometer * distance;
                Distance += distance;
            }
        }
    }
}