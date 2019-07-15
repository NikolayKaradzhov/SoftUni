namespace PizzaCalories.Models
{
    using System;
    using PizzaCalories.Constraints;
    using PizzaCalories.Exceptions;

    public class Topping
    {
        private string type;
        private decimal weight;

        public Topping(string type, decimal weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;

            private set
            {
                if (value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingType, value));
                }

                this.type = value;
            }
        }

        public decimal Weight
        {
            get => this.weight;

            private set
            {
                if (value < LengthConstraints.MinToppingWeight || value > LengthConstraints.MaxToppingWeight)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingWeight, this.Type));
                }

                this.weight = value;
            }
        }

        public decimal TotalCalories()
        {
            decimal result = 2.0m * this.Weight;

            result = ExecuteToppingType(result);

            return result;
        }

        private decimal ExecuteToppingType(decimal result)
        {
            if (this.Type.ToLower() == "meat")
            {
                result *= 1.2m;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                result *= 0.8m;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                result *= 1.1m;
            }
            else if (this.Type.ToLower() == "sauce")
            {
                result *= 0.9m;
            }

            return result;
        }
    }
}