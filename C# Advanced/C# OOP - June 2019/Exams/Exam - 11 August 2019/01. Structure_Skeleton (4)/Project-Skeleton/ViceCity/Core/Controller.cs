using System;
using System.Collections.Generic;
using System.Linq;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private const string MainPlayerNameKey = "Vercetti";
        private const string FullNameMainPlayer = "Tommy Vercetti";
        private const int InitialMainPlayerHealthPoints = 100;
        private readonly List<IPlayer> players;
        private readonly GunRepository gunRepository;
        private readonly GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.players = new List<IPlayer>();
            this.players.Add(new MainPlayer());
            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddPlayer(string name)
        {
            IPlayer player = (CivilPlayer)players.FirstOrDefault(p => p.Name == name);

            players.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            if (type != nameof(Pistol) && type != nameof(Rifle))
            {
                return $"Invalid gun type!";
            }

            IGun gun = null;

            switch (type)
            {
                case "Rifle":
                    gun = new Rifle(name);
                    break;

                case "Pistol":
                    gun = new Pistol(name);
                    break;

                default:
                    break;
            }

            this.gunRepository.Add(gun);

            return $"Successfully added {gun.Name} of type: {gun.GetType().Name}";
        }

        public string AddGunToPlayer(string name)
        {
            var player = players.FirstOrDefault(p => p.Name == name);

            var gun = guns.Remove(guns[0]);

            if (guns.Count == 0)
            {
                return $"There are no guns in the queue!";
            }

            if (player.Name == "Vercetti")
            {
                return $"Successfully added {gun} to the Main Player: Tommy Vercetti";
            }

            if (player.Name == null)
            {
                return $"Civil player with that name doesn't exists!";
            }

            return $"Successfully added {gun.GetType().Name} to the Civil Player: {name}";
        }

        public string Fight()
        {
            return $"";
        }
    }
}