using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        private string _name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = _name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this._name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }

                this._name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {this.machines.Count} machines");

            foreach (var machine in machines)
            {
                sb.AppendLine(machine.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
