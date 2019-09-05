using System;
using System.Linq;
using System.Reflection;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Models.Foods.Factories
{
    public class FoodFactory
    {
        public IFood CreateFood(string type, string name, decimal price)
        {
            Type foodType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            IFood food = (IFood)Activator.CreateInstance(foodType, name, price);

            return food;
        }
    }
}