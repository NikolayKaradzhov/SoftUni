using System;
using System.Linq;
using System.Reflection;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Models.Drinks.Factories
{
    public class DrinkFactory
    {
        public IDrink CreateDrink(string type, string name, int servingSize, string brand)
        {
            Type drinkType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == name);

            IDrink drink = (IDrink) Activator.CreateInstance(drinkType, name, servingSize, brand);

            return drink;
        }
    }
}