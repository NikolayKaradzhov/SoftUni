using System;
using System.Collections.Generic;
using System.Text;

namespace p07.RawData
{
    class Car
    {
        public Car(string model, Engine engine, Cargo cargo, List<Tire> tire)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tire = tire;
        }

        public string Model
        {
            get;
            set;
        }
        public Engine Engine
        {
            get;
            set;
        }
        public Cargo Cargo
        {
            get;
            set;
        }
        public List<Tire> Tire
        {
            get;
            set;
        }
    }
}