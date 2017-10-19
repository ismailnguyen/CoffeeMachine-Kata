namespace CoffeeMachine
{
    public class CoffeeMaker : DrinkMaker
    {
        private const string COFFEE_CODE = "C";
        private const double COFFEE_PRICE = 0.60;

        public CoffeeMaker()
        {
            Drink = new Drink(COFFEE_CODE, COFFEE_PRICE);
        }
    }
}