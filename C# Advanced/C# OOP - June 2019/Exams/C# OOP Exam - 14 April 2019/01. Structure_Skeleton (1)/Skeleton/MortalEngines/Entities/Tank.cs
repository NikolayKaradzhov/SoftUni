﻿using System;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; protected set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;

                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.DefenseMode = false;

                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string deffenceModeOutput = this.DefenseMode == true ? "ON" : "OFF";

            return base.ToString() +
                   Environment.NewLine +
                   $" *Defense: {deffenceModeOutput}";
        }
    }
}