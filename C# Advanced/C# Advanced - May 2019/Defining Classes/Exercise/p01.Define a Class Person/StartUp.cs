using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person personOne = new Person();
            Person personTwo = new Person();

            personOne.Name = "Aleks";
            personOne.Age = 24;

            personTwo.Name = "Niki";
            personTwo.Age = 28;

            Family members = new Family();

            members.AddMember(personOne);
            members.AddMember(personTwo);

            var oldestPerson = members.GetOldestMember();

            Console.WriteLine(oldestPerson.Name + " " + oldestPerson.Age);
        }
    }
}