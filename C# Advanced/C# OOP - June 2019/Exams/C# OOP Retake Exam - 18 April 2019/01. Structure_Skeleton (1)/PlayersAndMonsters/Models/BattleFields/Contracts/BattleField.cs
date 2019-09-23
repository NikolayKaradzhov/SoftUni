using System;
using System.Linq;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Models.BattleFields.Contracts
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            //Check if ANY of the players is dead
            //•	If one of the users is dead, throw new ArgumentException with message "Player is dead!"
            if (attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
            {
                throw new ArgumentException("Player is dead!");
            }

            //Check if attack player is begginer
            if (attackPlayer.GetType().Name == nameof(Beginner))
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            //Check if enemyPlayer is begginer
            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            //•	Before the fight, both players get bonus health points from their deck.

            int attackPlayerHealthBonus = attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            int enemyPlayerHealthBonus = enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            attackPlayer.Health += attackPlayerHealthBonus;
            enemyPlayer.Health += enemyPlayerHealthBonus;

            //•	Attacker attacks first and after that the enemy attacks. If one of the players is dead you should stop the fight.

            while (true)
            {
                int attackerDamagePoints = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                enemyPlayer.TakeDamage(attackerDamagePoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                int enemyDamagePoints = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);

                attackPlayer.TakeDamage(enemyDamagePoints);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}