namespace Fetching_results_with_ADO.NET
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(DbConfig.ConnectionString);

            using (connection)
            {
                try
                {
                    connection.Open();

                    foreach (var createTableCommand in DbConfig.CreateTableCommands)
                    {
                        SqlCommand createCommand = new SqlCommand(createTableCommand, connection);

                        createCommand.ExecuteNonQuery();
                    }

                    foreach (var insertCommandStatements in DbConfig.InsertCommands)
                    {
                        SqlCommand insertCommand = new SqlCommand(insertCommandStatements, connection);

                        insertCommand.ExecuteNonQuery();
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
}