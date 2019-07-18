namespace FoodShortage
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
                List<string> bdayList = new List<string>();

                while (input != "End")
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (tokens[0] == "Citizen")
                    {
                        string citizenName = tokens[1];
                        int age = int.Parse(tokens[2]);
                        string id = tokens[3];
                        string birthDate = tokens[4];

                        bdayList.Add(birthDate);

                        Citizen citizen = new Citizen(citizenName, age, id);
                    }
                    else if (tokens[0] == "Robot")
                    {
                        string robotModel = tokens[1];
                        string id = tokens[2];

                        Robot robot = new Robot(robotModel, id);
                    }
                    else if (tokens[0] == "Pet")
                    {
                        string name = tokens[1];
                        string birthDate = tokens[2];

                        Pet pet = new Pet(name, birthDate);

                        bdayList.Add(birthDate);
                    }

                    input = Console.ReadLine();
                }

                string year = Console.ReadLine();

                foreach (var date in bdayList)
                {
                    if (date.EndsWith(year))
                    {
                        Console.WriteLine(date);
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