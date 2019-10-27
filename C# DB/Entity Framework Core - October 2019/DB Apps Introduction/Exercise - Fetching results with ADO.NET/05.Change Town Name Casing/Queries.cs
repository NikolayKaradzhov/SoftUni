namespace _05.Change_Town_Name_Casing
{
    public class Queries
    {
        public const string UpdateTownQuery = @"UPDATE Towns 
                                                SET Name = UPPER(Name)
                                                WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public const string GetCountryTowns = @"SELECT t.Name
                                                FROM Towns AS t
                                                JOIN Countries AS c ON t.CountryCode = c.Id
                                                WHERE c.Name = @countryName";
    }
}