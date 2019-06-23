using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.data = new List<Astronaut>();
        }

        public int Count => this.data.Count();

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Astronaut astronaut)
        {
            int currentCapacity = this.data.Count();

            if (currentCapacity < this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string astronautName)
        {
            Astronaut astronaut = data.FirstOrDefault(n => n.Name == astronautName);

            if (data.Contains(astronaut))
            {
                data.Remove(astronaut);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Astronaut GetOldestAstronaut()
        {
            int oldesAstronaut = this.data.Max(a => a.Age);

            return this.data.FirstOrDefault(a => a.Age == oldesAstronaut);
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data.FirstOrDefault(a => a.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (Astronaut astronaut in this.data)
            {
                sb.Append($"{astronaut}{Environment.NewLine}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}