using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Core
{
    using Contracts;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;
        private IList<ITank> tanks;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
            this.tanks = new List<ITank>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }

            IPilot pilot = new Pilot(name);

            pilots.Add(pilot);

            return $"Pilot {name} hired";
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.tanks.Any(t => t.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }

            ITank tank = new Tank(name, attackPoints, defensePoints);

            tanks.Add(tank);

            return $"Tank {name} manufactured - attack: {attackPoints}; defense: {defensePoints}";
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            throw new System.NotImplementedException();
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            throw new System.NotImplementedException();
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            throw new System.NotImplementedException();
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots.FirstOrDefault(p => p.Name == pilotReporting);

            //if (pilot == null)
            //{
                
            //}

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.FirstOrDefault(m => m.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            throw new System.NotImplementedException();
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            throw new System.NotImplementedException();
        }
    }
}