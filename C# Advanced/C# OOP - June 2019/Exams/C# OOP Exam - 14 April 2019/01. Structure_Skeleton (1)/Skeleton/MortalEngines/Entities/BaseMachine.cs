using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double HealthPoints { get; set; }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                if (pilot == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public double AttackPoints { get; }

        public double DefensePoints { get; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double difference = Math.Abs(this.AttackPoints - target.HealthPoints);

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }
            else
            {
                target.HealthPoints -= difference;
            }

            this.Targets.Add(target.Name);
        }
    }
}