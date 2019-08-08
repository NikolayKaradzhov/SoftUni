using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double PowerMotorcycleCubucCentimeters = 450;
        private const double PowerMotorcycleMinHP = 70;
        private const double PowerMotorcycleMaxHP = 100;
        private int _horsePower;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, PowerMotorcycleCubucCentimeters)
        {
        }

        public override int HorsePower
        {
            get { return this._horsePower; }

            protected set
            {
                if (value < PowerMotorcycleMinHP || value > PowerMotorcycleMaxHP)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this._horsePower = value;
            }
        }
    }
}
