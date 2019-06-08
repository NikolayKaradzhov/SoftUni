using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family members = new Family();

            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                members.AddMember(person);
            }

            List<Person> over30s = members.FilterPersonByAgeOver30();

            foreach (var member in over30s)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}