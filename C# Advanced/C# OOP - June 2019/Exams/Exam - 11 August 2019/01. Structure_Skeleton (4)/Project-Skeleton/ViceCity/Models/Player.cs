using System;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;

        public Player(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }

                this.name = value;
            }
        }

        public bool IsAlive { get; }

        public IRepository<IGun> GunRepository { get; }

        public int LifePoints
        {
            get { return this.lifePoints; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!e");
                }

                this.lifePoints = value;
            }
        }

        public void TakeLifePoints(int points)
        {
            this.LifePoints -= points;
        }
    }
}