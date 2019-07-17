namespace BorderControl
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            try
            {
                string input = Console.ReadLine();
                List<string> idList = new List<string>();

                while (input != "End")
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (tokens.Length == 3)
                    {
                        string citizenName = tokens[0];
                        int age = int.Parse(tokens[1]);
                        string id = tokens[2];

                        idList.Add(id);

                        Citizen citizen = new Citizen(citizenName, age, id);
                    }
                    else if (tokens.Length == 2)
                    {
                        string robotModel = tokens[0];
                        string id = tokens[1];

                        idList.Add(id);

                        Robot robot = new Robot(robotModel, id);
                    }

                    input = Console.ReadLine();
                }

                string fakeId = Console.ReadLine();

                foreach (var id in idList)
                {
                    if (id.EndsWith(fakeId))
                    {
                        Console.WriteLine(id);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}