namespace PizzaCalories
{
    using System;
    using PizzaCalories.Constraints;
    using PizzaCalories.Exceptions;

    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private decimal weight;

        public Dough(string flourType, string bakingTechnique, decimal weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (value != "white" || value != "wholegrain")
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }

                this.flourType = value;
            }
        }

        public decimal Weight
        {
            get => this.weight;

            private set
            {
                if (value < Constraints.LengthConstraints.MinDoughWeight || value > LengthConstraints.MaxDoughWeight)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDoughWeight);
                }

                this.weight = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (value != "Crispy" || value != "Chewy" || value != "Homemade")
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTypeOfDough);
                }

                this.bakingTechnique = value;
            }
        }

        public decimal TotalCalories()
        {
            decimal result = this.Weight * 2;

            result = ExecuteFlourType(result);
            result = ExecuteBakeType(result);

            return result;
        }

        private decimal ExecuteFlourType(decimal result)
        {
            if (this.FlourType.ToLower() == "white")
            {
                result *= 1.5m;
            }
            else if (this.FlourType.ToLower() == "wholegrain")
            {
                result *= 1.0m;
            }

            return result;
        }

        private decimal ExecuteBakeType(decimal result)
        {
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                result *= 0.9m;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                result *= 1.1m;
            }
            else if (this.BakingTechnique.ToLower() == "homemade")
            {
                result *= 1.0m;
            }

            return result;
        }
    }
}