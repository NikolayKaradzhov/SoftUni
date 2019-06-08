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


        }
    }
}