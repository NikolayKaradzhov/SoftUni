using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private int _horsePower;
        private const int SpeedMotorcycleMinHP = 50;
        private const int SpeedMotorcycleMaxHP = 69;
        private const double SpeedMotorcycleCubicCentimeters = 125;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, SpeedMotorcycleCubicCentimeters)
        {
        }

        public override int HorsePower
        {
            get { return this._horsePower; }
            protected set
            {
                if (value < SpeedMotorcycleMinHP || value > SpeedMotorcycleMaxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
            }
        }
    }
}
