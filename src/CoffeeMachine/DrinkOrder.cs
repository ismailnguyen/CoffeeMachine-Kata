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

        public int GetSugarQuantity()
        {
            return drink.GetSugarQuantity();
        }
    }
}