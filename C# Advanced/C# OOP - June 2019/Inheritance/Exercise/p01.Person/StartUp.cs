namespace P01.Person
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child firstChild = new Child(name, age);

            Console.WriteLine(firstChild);
        }
    }
}