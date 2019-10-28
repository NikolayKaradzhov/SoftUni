namespace _06.Remove_Villain
{
    public class Queries
    {
        public const string TakeVillainId = "SELECT Name FROM Villains WHERE Id = @villainId";

        public const string DeleteMinionVillains = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";

        public const string DeleteFromVillains = "DELETE FROM Villains WHERE Id = @villainId";
    }
}