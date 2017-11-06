namespace CoffeeMachine
{
    public class DrinkOrder : IDrinkOrder
    {
        private IDrink drink;

        public DrinkOrder(IDrink drink)
        {
            this.drink = drink;
        }

        public void GetDrinkCode()
        {
        }
    }
}