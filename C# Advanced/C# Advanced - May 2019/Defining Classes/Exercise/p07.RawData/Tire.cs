using System;
using System.Collections.Generic;
using System.Text;

namespace p07.RawData
{
    class Tire
    {
        private double tirePressure;
        private int tireAge;

        public Tire(double pressure, int age)
        {
            this.TirePressure = pressure;
            this.TireAge = age;
        }

        public double TirePressure
        {
            get
            {
                return this.tirePressure;
            }
            set
            {
                this.tirePressure = value;
            }
        }
        public int TireAge
        {
            get
            {
                return this.tireAge;
            }
            set
            {
                this.tireAge = value;
            }
        }
    }
}