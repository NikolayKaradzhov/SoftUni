namespace _03.Minion_Names
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Input Id: ");

                int id = int.Parse(Console.ReadLine());

                string connectionString = @"Server = BGL063; Database = MinionsDB; Integrated Security = true";

                SqlConnection connection = new SqlConnection(connectionString);

                using (connection)
                {
                    connection.Open();

                    SqlCommand villianNameCommand = new SqlCommand(Queries.VillainName, connection);

                    villianNameCommand.Parameters.AddWithValue("@Id", id);

                    string villianName = (string)villianNameCommand.ExecuteScalar();

                    if (villianName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villianName}");

                    SqlCommand minionsCommand = new SqlCommand(Queries.MinionNames, connection);

                    minionsCommand.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = minionsCommand.ExecuteReader();

                    using (reader)
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                            return;
                        }

                        while (reader.Read())
                        {
                            long rowNumber = (long)reader[0];
                            string minionName = (string)reader[1];
                            int minionAge = (int)reader[2];

                            Console.WriteLine($"{rowNumber}. {minionName} {minionAge}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}