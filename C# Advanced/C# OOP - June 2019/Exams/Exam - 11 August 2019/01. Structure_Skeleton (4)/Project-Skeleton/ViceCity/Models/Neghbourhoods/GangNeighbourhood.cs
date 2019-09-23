using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            while (true)
            {
                IGun gun = mainPlayer.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                IPlayer targetPlayer = civilPlayers.FirstOrDefault(t => t.IsAlive == true);

                if (targetPlayer == null)
                {
                    break;
                }

                int damagePoints = gun.Fire();
                targetPlayer.TakeLifePoints(damagePoints);
            }

            while (true)
            {
                IPlayer player = civilPlayers.FirstOrDefault(t => t.IsAlive == true);

                if (player == null)
                {
                    break;
                }

                IGun gun = player.GunRepository.Models.FirstOrDefault(g => g.CanFire == true);

                if (gun == null)
                {
                    break;
                }

                int damagePoints = gun.Fire();
                mainPlayer.TakeLifePoints(damagePoints);

                if (mainPlayer.IsAlive == false)
                {
                    break;
                }
            }
        }
    }
}