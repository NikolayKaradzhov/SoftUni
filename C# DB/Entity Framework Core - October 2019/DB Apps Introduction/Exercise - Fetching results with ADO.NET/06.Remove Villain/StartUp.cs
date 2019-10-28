using System.Runtime.CompilerServices;

namespace _06.Remove_Villain
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        private static string connectionString = @"Server = BGL063; Database = MinionsDB; Integrated Security = true";
        private static SqlConnection connection = new SqlConnection(connectionString);

        private static SqlTransaction transaction;

        public static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());

            connection.Open();

            using (connection)
            {
                transaction = connection.BeginTransaction();

                try
                {
                    SqlCommand command = new SqlCommand();

                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = Queries.TakeVillainId;
                    command.Parameters.AddWithValue("@villainId", villainId);

                    object value = command.ExecuteScalar();

                    if (value == null)
                    {
                        throw new NullReferenceException("No such villain found.");
                    }

                    string villainName = (string) value;

                    command.CommandText = Queries.DeleteMinionVillains;

                    int rowsAffected = command.ExecuteNonQuery();

                    command.CommandText = Queries.DeleteFromVillains;

                    command.ExecuteNonQuery();

                    transaction.Commit();

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{rowsAffected} minions were released.");

                }
                catch (ArgumentNullException ane)
                {
                    try
                    {
                        Console.WriteLine(ane.Message);
                        transaction.Rollback();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                catch (Exception e)
                {
                    try
                    {
                        Console.WriteLine(e.Message);
                        transaction.Rollback();
                    }
                    catch (Exception re)
                    {
                        Console.WriteLine(re.Message);
                    }
                }
            }
        }
    }
}