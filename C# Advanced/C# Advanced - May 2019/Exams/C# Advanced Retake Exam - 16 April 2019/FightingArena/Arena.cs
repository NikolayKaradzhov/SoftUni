using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FightingArena
{
    class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string arenaName)
        {
            Name = arenaName;

            gladiators = new List<Gladiator>();
        }

        public int Count
        {
            get
            {
                return gladiators.Count;
            }
                
        }
        public string Name { get; set; }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string gladiatorName)
        {
            gladiators.Remove(gladiators.FirstOrDefault(g => g.Name == gladiatorName));
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            int highestStatPower = int.MinValue;

            int currentGladiatorStatPower = 0;

            foreach (var gladiator in gladiators)
            {
                currentGladiatorStatPower = gladiator.GetStatPower();

                if (currentGladiatorStatPower > highestStatPower)
                {
                    highestStatPower = currentGladiatorStatPower;
                }
            }

            Gladiator gladiatorWithHighestStatPower = this.gladiators.FirstOrDefault(g => g.GetStatPower() == highestStatPower);

            return gladiatorWithHighestStatPower;
        }

        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            int highestWeaponPower = int.MinValue;

            int gladiatorCurrentWeaponPower = 0;

            foreach (var gladiator in gladiators)
            {
                gladiatorCurrentWeaponPower = gladiator.GetWeaponPower();

                if (gladiatorCurrentWeaponPower > highestWeaponPower)
                {
                    highestWeaponPower = gladiatorCurrentWeaponPower;
                }
            }

            Gladiator gladiatorWithHighestWeaponPower = gladiators.FirstOrDefault(g => g.GetWeaponPower() == highestWeaponPower);

            return gladiatorWithHighestWeaponPower;
        }

        public Gladiator GetGladitorWithHighestTotalPower()
        {
            int highestTotalPower = int.MinValue;

            int totalPower = 0;

            foreach (var gladiator in gladiators)
            {
                totalPower = gladiator.GetTotalPower();

                if (totalPower > highestTotalPower)
                {
                    highestTotalPower = totalPower;
                }
            }

            Gladiator gladiatorWithHighestTotalPower = gladiators.FirstOrDefault(g => g.GetTotalPower() == highestTotalPower);

            return gladiatorWithHighestTotalPower;
        }
    }
}