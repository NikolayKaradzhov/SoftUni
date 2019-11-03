USE MinionsDB

SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
FROM Villains AS v
JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
JOIN Minions AS m ON mv.MinionId = m.Id
GROUP BY v.Id, v.Name
HAVING COUNT(mv.VillainId) > 3
ORDER BY COUNT(mv.VillainId)

SELECT t.Name
FROM Towns AS t
JOIN Countries AS c ON t.CountryCode = c.Id
WHERE c.Name = @countryName