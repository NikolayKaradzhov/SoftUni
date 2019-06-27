using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace p02.MOBA_Challanger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var playerPool = new Dictionary<string, Dictionary<string, int>>();

            while (input != "Season end")
            {
                if (input.Contains("vs"))
                {
                    string[] split = input.Split(" vs ");
                    string player1 = split[0];
                    string player2 = split[1];

                    if (playerPool.ContainsKey(player1) && playerPool.ContainsKey(player2))
                    {
                        string[] firstplayerpositions = playerPool[player1].Keys.ToArray();

                        foreach (var secondPlayerPositions in playerPool[player2].Keys)
                        {
                            if (firstplayerpositions.Contains(secondPlayerPositions))
                            {
                                int firstPlayerTotalSkill = playerPool[player1].Values.Sum();
                                int secondPlayerTotalSkill = playerPool[player2].Values.Sum();

                                if (firstPlayerTotalSkill > secondPlayerTotalSkill)
                                {
                                    playerPool.Remove(player2);
                                    break;
                                }
                                else if (secondPlayerTotalSkill > firstPlayerTotalSkill)
                                {
                                    playerPool.Remove(player1);
                                    break;
                                }
                                else if (firstPlayerTotalSkill == secondPlayerTotalSkill)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    string[] split = input.Split(" -> ");
                    string player = split[0];
                    string position = split[1];
                    int skill = int.Parse(split[2]);

                    if (!playerPool.ContainsKey(player))
                    {
                        Dictionary<string, int> positionSkill = new Dictionary<string, int>();
                        positionSkill.Add(position, skill);
                        playerPool.Add(player, positionSkill);
                    }
                    else if (playerPool.ContainsKey(player) && !playerPool[player].ContainsKey(position))
                    {
                        playerPool[player].Add(position, skill);
                    }
                    else
                    {
                        if (playerPool[player][position] < skill)
                        {
                            playerPool[player][position] = skill;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var kvp in playerPool.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Values.Sum()} skill");

                foreach (var item in kvp.Value.OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                {
                    Console.WriteLine($"- {item.Key} <::> {item.Value}");
                }
            }
        }
    }
}
