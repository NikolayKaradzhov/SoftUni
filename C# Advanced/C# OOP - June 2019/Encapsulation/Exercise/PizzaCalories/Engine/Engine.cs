namespace PizzaCalories
{
    using System;
    using PizzaCalories.Models;

    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaItems = Console.ReadLine().Split();
                string pizzaName = pizzaItems[1];

                string[] doughItems = Console.ReadLine().Split();

                string flour = doughItems[1];
                string backeType = doughItems[2];
                decimal weight = decimal.Parse(doughItems[3]);
                Dough dough = new Dough(flour, backeType, weight);

                Pizza pizza = new Pizza(pizzaName, dough);

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] toppingItems = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string type = toppingItems[1];
                    decimal weigh = decimal.Parse(toppingItems[2]);
                    Topping topping = new Topping(type, weigh);
                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine(pizza.ToString());
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}