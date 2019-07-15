namespace PizzaCalories
{
    using System;
    using PizzaCalories.Constraints;
    using PizzaCalories.Exceptions;
    using System.Linq;
    using PizzaCalories.Models;
    using System.Collections.Generic;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private readonly List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > LengthConstraints.PizzaNameMaxLength)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPizzaNameLength);
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get => this.dough;

            private set => this.dough = value;
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == LengthConstraints.MaxToppingsCount)
            {
                throw new ArgumentException(ExceptionMessages.InvalidToppingsCount);
            }
            else
            {
                this.toppings.Add(topping);
            }
        }

        public override string ToString()
        {
            decimal totalCalories = this.Dough.TotalCalories() + this.toppings.Sum(t => t.TotalCalories());
            return $"{this.Name} - {totalCalories:F2} Calories.";
        }
    }
}