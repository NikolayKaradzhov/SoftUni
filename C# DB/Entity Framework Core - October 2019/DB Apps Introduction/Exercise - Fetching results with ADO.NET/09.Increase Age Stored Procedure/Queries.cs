namespace _09.Increase_Age_Stored_Procedure
{
    public class Queries
    {
        public const string UpdateAgeStoredProc = "CREATE PROC usp_GetOlder @id INT AS UPDATE Minions SET Age += 1 WHERE Id = @id";

        public const string SelectNameAgeQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";
    }
}