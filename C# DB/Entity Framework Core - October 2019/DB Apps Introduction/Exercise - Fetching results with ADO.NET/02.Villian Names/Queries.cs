﻿namespace _02.Villian_Names
{
    public class Queries
    {
        public static string VilliansWithMinions = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
                                                    FROM Villains AS v
                                                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                                    JOIN Minions AS m ON mv.MinionId = m.Id
                                                    GROUP BY v.Id, v.Name
                                                    HAVING COUNT(mv.VillainId) > 3
                                                    ORDER BY COUNT(mv.VillainId)";
    }
}