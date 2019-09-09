using System;
using System.Linq;
using System.Text;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IRider> ridersRepository;
        private readonly IRepository<IMotorcycle> motorcycleRepository;
        private readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            this.ridersRepository = new RiderRepository();
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
        }

        public string CreateRider(string riderName)
        {
            IRider rider = ridersRepository.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException($"Rider {rider.Name} is already created.");
            }

            IRider riderr = new Rider(riderName);
            return $"Rider {riderr.Name} is created.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = motorcycleRepository.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException($"Motorcycle {motorcycle.Model} is already created.");
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

            string result = $"{motorcycle.GetType().Name} {model} is created.";

            return result;
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {race.Name} is already created.");
            }

            race = new Race(name, laps);

            raceRepository.Add(race);

            return $"Race {race.Name} is created.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            IRider rider = this.ridersRepository.GetByName(riderName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {race.Name} could not be found.");
            }

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {rider.Name} could not be found.");
            }

            race.AddRider(rider);

            return $"Rider {rider.Name} added in {race.Name} race.";
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = this.ridersRepository.GetByName(riderName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {rider.Name} could not be found.");
            }

            IMotorcycle motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycle.Model} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);

            return $"Rider {rider.Name} received motorcycle {motorcycle.Model}.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {race.Name} could not be found.");
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }

            var riders = race.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rider {riders[0]} wins {race.Name} race.");
            sb.AppendLine($"Rider {riders[1]} is second in {race.Name} race.");
            sb.AppendLine($"Rider {riders[2]} is third in {race.Name} race.");

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}