namespace CoffeeMachine
{
    public class TeaMaker : DrinkMaker
    {
        private const string TEA_CODE = "T";
        private const double TEA_PRICE = 0.40;

        public TeaMaker()
        {
            Drink = new Drink(TEA_CODE, TEA_PRICE);
        }
    }
}