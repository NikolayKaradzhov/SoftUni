using System;
using System.Collections.Generic;
using System.Linq;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private List<IPlayer> players;
        private List<IGun> guns;

        public Controller()
        {
            players = new List<IPlayer>();
            guns = new List<IGun>();
        }

        public string AddPlayer(string name)
        {
            var player = players.FirstOrDefault(p => p.Name == name);

            players.Add(player);

            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {
            var gun = guns.FirstOrDefault(g => g.GetType().Name == type);

            if (gun == null)
            {
                return $"Invalid gun type!";
            }

            guns.Add(gun);

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
            var mainPlayer = players.FirstOrDefault(p => p.Name == "Vercetti");

            mainPlayer.tak
        }
    }
}