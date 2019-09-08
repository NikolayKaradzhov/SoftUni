using System;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IRider> ridersRepository;
        private readonly IRepository<IMotorcycle> motorcycleRepository;

        public ChampionshipController()
        {
            this.ridersRepository = new RiderRepository();
            this.motorcycleRepository = new MotorcycleRepository();
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
            throw new NotImplementedException();
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            throw new NotImplementedException();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            throw new NotImplementedException();
        }

        public string StartRace(string raceName)
        {
            throw new NotImplementedException();
        }
    }
}
