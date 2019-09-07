using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            IPilot pilot = new Pilot(name);

            this.pilots.Add(pilot);

            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            IMachine tankMachine = new Tank(name, attackPoints, defensePoints);

            machines.Add(tankMachine);

            return $"Tank {tankMachine.Name} manufactured - attack: {tankMachine.AttackPoints:F2}; defense: {tankMachine.DefensePoints:F2}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);

            this.machines.Add(fighter);

            return
                $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == selectedPilotName);

            if (pilot == null)
            {
                return $"Pilot {pilot.Name} could not be found";
            }

            IMachine machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);

            if (machine == null)
            {
                return $"Machine {machine.Name} could not be found";
            }

            if (machine.Pilot != null)
            {
                return $"Machine {machine.Name} is already occupied";
            }

            machine.Pilot = pilot;
            pilot.AddMachine(machine);

            return $"Pilot {pilot.Name} engaged machine {machine.Name}";
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackMachine = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);

            if (attackMachine == null)
            {
                return $"Machine {attackMachine.Name} could not be found";
            }

            IMachine defendingMachine = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (defendingMachine == null)
            {
                return $"Machine {defendingMachine.Name} could not be found";
            }

            if (attackMachine.HealthPoints <= 0)
            {
                return $"Dead machine {attackMachine.Name} cannot attack or be attacked";
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachine.Name} cannot attack or be attacked";
            }

            attackMachine.Attack(defendingMachine);

            return
                $"Machine {defendingMachine.Name} was attacked by machine {attackMachine.Name} - current health: {defendingMachine.HealthPoints:F2}";
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            if (pilot == null)
            {
                return $"Pilot {pilot.Name} could not be found";
            }

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines.FirstOrDefault(m => m.Name == machineName);

            if (machine == null)
            {
                return $"Machine {machine.Name} could not be found";
            }

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IMachine machine = this.machines.FirstOrDefault(f => f.Name == fighterName);

            if (machine == null)
            {
                return $"Machine {machine.Name} could not be found";
            }

            IFighter fighter = (IFighter) machine;

            fighter.ToggleAggressiveMode();

            return $"Fighter {fighter.Name} toggled aggressive mode";
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            IMachine machine = machines.FirstOrDefault(m => m.Name == tankName);

            if (machine == null)
            {
                return $"Machine {machine.Name} could not be found";
            }

            ITank tank = (ITank) machine;

            tank.ToggleDefenseMode();

            return $"Tank {tank.Name} toggled defense mode";
        }
    }
}