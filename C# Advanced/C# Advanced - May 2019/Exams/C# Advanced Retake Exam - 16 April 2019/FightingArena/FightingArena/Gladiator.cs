using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    class Gladiator
    {

        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            Name = name;
            Stat = stat;
            Weapon = weapon;
        }
        public string Name { get; set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public override string ToString()
        {
            return $"{Name} - {GetTotalPower()}" + Environment.NewLine
                 + $"Weapon Power: {GetWeaponPower()}" + Environment.NewLine
                 + $"Stat Power: {GetStatPower()}";
        }

        public int GetTotalPower()
        {
            int totalPower = Stat.Strength + Stat.Flexibility + Stat.Agility + Stat.Skills + Stat.Intelligence
                + Weapon.Size + Weapon.Solidity + Weapon.Sharpness;

            return totalPower;
        }

        public int GetWeaponPower()
        {
            int weaponPower = Weapon.Size + Weapon.Solidity + Weapon.Sharpness;

            return weaponPower;
        }

        public int GetStatPower()
        {
            int statPower = Stat.Strength + Stat.Flexibility + Stat.Agility + Stat.Skills + Stat.Intelligence;

            return statPower;
        }
    }
}