using System;

namespace CoffeeMachine
{
    public class DrinkOrder : IDrinkOrder
    {
        private IDrink drink;

        public DrinkOrder(IDrink drink)
        {
            this.drink = drink;
        }

        public string GetDrinkCode()
        {
            return drink.GetCode();
        }

        public double GetPrice()
        {
            return drink.GetPrice();
        }

        public int GetSugarQuantity()
        {
            return drink.GetSugarQuantity();
        }
    }
}