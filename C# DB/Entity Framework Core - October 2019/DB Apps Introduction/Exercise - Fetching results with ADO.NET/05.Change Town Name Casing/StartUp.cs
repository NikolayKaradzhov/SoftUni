using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05.Change_Town_Name_Casing
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string countryInput = Console.ReadLine();

            string connectionString = @"Server = BGL063; Database = MinionsDB; Integrated Security = true";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Queries.UpdateTownQuery, connection);

                using (command)
                {
                    command.Parameters.AddWithValue("@countryName", countryInput);

                    int countRowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine($"{countRowsAffected} town names were affected.");
                }

                command = new SqlCommand(Queries.GetCountryTowns, connection);

                using (command)
                {
                    command.Parameters.AddWithValue("@countryName", countryInput);

                    List<string> cities = new List<string>();

                    SqlDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            cities.Add((string)reader[0]);
                        }
                    }

                    if (cities.Count == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                    }
                    else
                    {
                        Console.WriteLine($"[{string.Join(", ", cities)}]");
                    }
                }
            }
        }
    }
}