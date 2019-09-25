using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Models.Riders.Contracts
{
    public class Rider : IRider
    {
        private string _name;
        
        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => _name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                _name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Motorcycle != null;

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(nameof(motorcycle), "Motorcycle cannot be null.");
            }

            this.Motorcycle = motorcycle;
        }
    }
}
