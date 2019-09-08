using System;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double PowerMotorcycleCubicCentimeters = 450;
        private const double PowerMotorcycleMinHP = 70;
        private const double PowerMotorcycleMaxHP = 100;

        private int horsepower;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, PowerMotorcycleCubicCentimeters)
        {
        }


        public override int HorsePower
        {
            get
            {
                return this.horsepower;
            }
            protected set
            {
                if (value < PowerMotorcycleMinHP || value > PowerMotorcycleMaxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsepower = value;
            }
        }
    }
}
