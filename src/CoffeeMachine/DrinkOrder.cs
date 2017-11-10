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
            var hotDrink = drink as IHotDrink;
            if (hotDrink != null)
            {
                return hotDrink.GetSugarQuantity();
            }

            return 0;
        }
    }
}