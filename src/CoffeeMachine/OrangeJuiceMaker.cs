namespace CoffeeMachine
{
    public class OrangeJuiceMaker : DrinkMaker
    {
        private const string ORANGE_JUICE_CODE = "O";
        private const double ORANGE_JUICE_PRICE = 0.60;

        public OrangeJuiceMaker()
        {
            Drink = new Drink(ORANGE_JUICE_CODE, ORANGE_JUICE_PRICE);
        }
    }
}
