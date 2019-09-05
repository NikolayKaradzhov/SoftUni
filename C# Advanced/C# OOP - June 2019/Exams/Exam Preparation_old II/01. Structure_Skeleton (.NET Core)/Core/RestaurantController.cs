using System.Collections;
using System.Collections.Generic;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Drinks.Factories;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Foods.Factories;
using SoftUniRestaurant.Models.Tables.Contracts;
using SoftUniRestaurant.Models.Tables.Factories;

namespace SoftUniRestaurant.Core
{
    using System;

    public class RestaurantController
    {
        private IList<IFood> menu;
        private IList<IDrink> drinks;
        private IList<ITable> tables;
        private FoodFactory foodFactory;
        private DrinkFactory drinkFactory;
        private TableFactory tableFactory;

        public RestaurantController(IList<IFood> menu, IList<IDrink> drinks, IList<ITable> tables)
        {
            this.menu = new List<IFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.foodFactory = new FoodFactory();
            this.drinkFactory = new DrinkFactory();
            this.tableFactory = new TableFactory();
        }

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = this.foodFactory.CreateFood(type, name, price);

            menu.Add(food);

            return $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = this.drinkFactory.CreateDrink(type, name, servingSize, brand);

            drinks.Add(drink);

            return $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = this.tableFactory.CreateTable(type, tableNumber, capacity);

            tables.Add(table);

            return $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            throw new NotImplementedException();
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            throw new NotImplementedException();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            throw new NotImplementedException();
        }

        public string LeaveTable(int tableNumber)
        {
            throw new NotImplementedException();
        }

        public string GetFreeTablesInfo()
        {
            throw new NotImplementedException();
        }

        public string GetOccupiedTablesInfo()
        {
            throw new NotImplementedException();
        }

        public string GetSummary()
        {
            throw new NotImplementedException();
        }
    }
}
