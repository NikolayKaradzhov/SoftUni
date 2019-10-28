using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PrintAllMinionNames
{
    using System.Data.SqlClient;

    public class StartUp
    {
        public static string connectionString = @"Server = BGL063; Database = MinionsDB; Integrated Security = true";
        private static SqlConnection connection = new SqlConnection(connectionString);

        public static void Main()
        {
            List<string> minionNames = new List<string>();

            using (connection)
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Queries.MinionNamesQuery, connection);

                using (command)
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        minionNames.Add((string)reader[0]);
                    }
                }

                Console.WriteLine($"Original Order:\n{string.Join(Environment.NewLine, minionNames)}");
            }

            Console.WriteLine();

            Console.WriteLine("Output:");

            while (minionNames.Count != 0)
            {
                Console.WriteLine(minionNames[0]);
                minionNames.RemoveAt(0);

                if (minionNames.Count == 0)
                {
                    break;
                }

                Console.WriteLine(minionNames.Last());
                minionNames.RemoveAt(minionNames.Count-1);
            }
        }
    }
}