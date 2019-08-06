using System;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Animals
{
    public abstract class Animal : IAnimal
    {
        private int energy;
        private int happiness;

        public Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Centre";
            this.IsAdopt = false;
            this.IsChipped = false;
            this.IsVaccinated = false;
        }

        public string Name { get; }

        public int Happiness
        {
            get { return this.happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get { return this.energy; }

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }

                this.energy = value;
            }
        }
        public int ProcedureTime { get; }
        public string Owner { get; }
        public bool IsAdopt { get; }
        public bool IsChipped { get; }
        public bool IsVaccinated { get; }
    }
}