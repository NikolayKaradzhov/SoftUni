namespace _04.Add_Project
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Dynamic;
    using System.Linq;
    using System.Reflection.Metadata;

    public class StartUp
    {
        public static int TownId;
        public static int MinionId;
        public static int VillainId;

        public static void Main()
        {
            List<string> minionInfo = Console.ReadLine()
                .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];

            List<string> villainInfo = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            string villainName = villainInfo[0];
            
            string connectionString = @"Server = BGL063; Database = MinionsDB; Integrated Security = true";

            SqlConnection connection = new SqlConnection(connectionString);

            using (connection)
            {
                connection.Open();

                ExecuteTownQuery(minionTown, connection);
                ExecuteMinionQuery(minionName, minionAge, connection);
                ExecuteVillainQuery(villainName, connection);
                ExecuteMinionVillainQuery(minionName, villainName, connection);
            }
        }

        private static void ExecuteMinionVillainQuery(string minionName, string villainName, SqlConnection connection)
        {
            SqlCommand insertMinionVillainCommand = new SqlCommand(Queries.InsertMinionVillain, connection);

            using (insertMinionVillainCommand)
            {
                insertMinionVillainCommand.Parameters.AddWithValue("@villainId", VillainId);
                insertMinionVillainCommand.Parameters.AddWithValue("@minionId", MinionId);

                insertMinionVillainCommand.ExecuteScalar();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }

        private static void ExecuteVillainQuery(string villainName, SqlConnection connection)
        {
            SqlCommand addVillainCommand = new SqlCommand(Queries.TakeVillainId, connection);

            using (addVillainCommand)
            {
                addVillainCommand.Parameters.AddWithValue("@Name", villainName);

                object targetId = addVillainCommand.ExecuteScalar();

                if (targetId != null)
                {
                    VillainId = (int) targetId;
                }
                else
                {
                    SqlCommand insertVillainCommand = new SqlCommand(Queries.InsertVillain, connection);

                    using (insertVillainCommand)
                    {
                        insertVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                        insertVillainCommand.ExecuteScalar();

                        Console.WriteLine($"Villain {villainName} was added to the database.");
                    }
                }
            }
        }

        private static void ExecuteMinionQuery(string minionName, int minionAge, SqlConnection connection)
        {
           SqlCommand addMinionCommand = new SqlCommand(Queries.TakeMinionId, connection);

           using (addMinionCommand)
           {
               addMinionCommand.Parameters.AddWithValue("@Name", minionName);

               object targetId = addMinionCommand.ExecuteScalar();

               if (targetId != null)
               {
                   MinionId = (int) targetId;
               }
               else
               {
                   SqlCommand insertMinionCommand = new SqlCommand(Queries.InsertMinion, connection);

                   using (insertMinionCommand)
                   {
                       insertMinionCommand.Parameters.AddWithValue("@nam", minionName);
                       insertMinionCommand.Parameters.AddWithValue("@age", minionAge);
                       insertMinionCommand.Parameters.AddWithValue("@townId", TownId);

                       insertMinionCommand.ExecuteScalar();

                       Console.WriteLine($"Minion {minionName} was added to the database.");
                   }
               }
           }
        }

        private static void ExecuteTownQuery(string minionTown, SqlConnection connection)
        {
            SqlCommand addTownCommand = new SqlCommand(Queries.TakeTownId, connection);

            using (addTownCommand)
            {
                addTownCommand.Parameters.AddWithValue("@townName", minionTown);

                object targetId = addTownCommand.ExecuteScalar();

                if (targetId != null)
                {
                    TownId = (int) targetId;
                }
                else
                {
                    SqlCommand insertTownCommand = new SqlCommand(Queries.InsertTown, connection);

                    using (insertTownCommand)
                    {
                        insertTownCommand.Parameters.AddWithValue("@townName", minionTown);
                        insertTownCommand.ExecuteScalar();

                        Console.WriteLine($"Town {minionTown} was added to the database.");
                    }
                }
            }
        }
    }
}