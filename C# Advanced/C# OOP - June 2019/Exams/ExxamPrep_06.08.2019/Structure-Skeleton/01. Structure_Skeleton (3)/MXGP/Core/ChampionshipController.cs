﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IRider> riderRepository;
        private readonly IRepository<IMotorcycle> motorcycleRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.riderRepository = new RiderRepository();
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateRider(string riderName)
        {
            var rider = riderRepository.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            rider = new Rider(riderName);

            this.riderRepository.Add(rider);

            string result = $"Rider {riderName} is created.";

            return result;
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorcycle = this.motorcycleRepository.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            this.motorcycleRepository.Add(motorcycle);

            string result = string.Empty;

            if (type == "Speed")
            {
                result = $"SpeedMotorcycle {model} is created.";
            }
            else
            {
                result = $"PowerMotorcycle {model} is created.";
            }

            return result;
        }

        public string CreateRace(string name, int laps)
        {
            var race = raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);
            raceRepository.Add(race);

            string result = $"Race {name} is created.";

            return result;
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = raceRepository.GetByName(raceName);
            var rider = riderRepository.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            race.AddRider(rider);

            var result = $"Rider {riderName} added in {raceName} race.";

            return result;
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepository.GetByName(riderName);
            var motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }

            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);

            string result = $"Rider {riderName} received motorcycle {motorcycleModel}.";

            return result;
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var riders = race.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rider {riders[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {riders[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {riders[2].Name} is third in {raceName} race.");

            raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}