namespace _02.Villian_Names
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(DbConfig.ConnectionString);

            try
            {
                using (connection)
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(Queries.VilliansWithMinions, connection);

                    SqlDataReader reader = (command.ExecuteReader());

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            string villianName = (string)reader[0];
                            int minionsCount = (int)reader[1];

                            Console.WriteLine($"{villianName} - {minionsCount}");
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