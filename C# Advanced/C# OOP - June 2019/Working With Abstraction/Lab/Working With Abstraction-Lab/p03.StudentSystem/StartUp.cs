using System;

namespace p03.StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            var commandParser = new CommandParser();
            var studentSystem = new StudentSystem();

            while (true)
            {
                var command = commandParser.Parse(Console.ReadLine());

                if (command.Name == "Create")
                {
                    var name = command.Arguments[0];
                    var age = int.Parse(command.Arguments[1]);
                    var grade = double.Parse(command.Arguments[2]);

                    studentSystem.Add(name, age, grade);
                }

                if (command.Name == "Show")
                {
                    var name = command.Arguments[0];

                    var student = studentSystem.Get(name);

                    Console.WriteLine(student);
                }

                if (command.Name == "Exit")
                {
                    break;
                }
            }
            
        }
    }
}
