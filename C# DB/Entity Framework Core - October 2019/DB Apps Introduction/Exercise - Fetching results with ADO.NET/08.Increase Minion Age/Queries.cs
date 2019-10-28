namespace _08.Increase_Minion_Age
{
    public class Queries
    {
        public const string UpdateMinionsQuery = "UPDATE Minions " +
                                                 "SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1" +
                                                 "WHERE Id = @Id";

        public const string SelectMinionInformation = "SELECT Name, Age FROM Minions";
    }
}