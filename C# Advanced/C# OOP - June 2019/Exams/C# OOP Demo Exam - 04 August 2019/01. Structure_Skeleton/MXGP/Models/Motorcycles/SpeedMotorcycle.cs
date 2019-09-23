using System;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double SpeedMotorcycleCubicCentimeters = 125;
        private const double SpeedMotorcycleMinHP = 50;
        private const double SpeedMotorcycleMaxHP = 69;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, SpeedMotorcycleCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < SpeedMotorcycleMinHP || value > SpeedMotorcycleMaxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }
    }
}