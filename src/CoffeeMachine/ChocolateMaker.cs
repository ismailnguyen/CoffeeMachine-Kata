namespace CoffeeMachine
{
    public class ChocolateMaker : DrinkMaker
    {
        private const string CHOCOLATE_CODE = "H";
        private const double CHOCOLATE_PRICE = 0.50;

        public ChocolateMaker()
        {
            Drink = new Drink(CHOCOLATE_CODE, CHOCOLATE_PRICE);
        }
    }
}