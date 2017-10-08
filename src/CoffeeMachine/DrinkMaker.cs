namespace CoffeeMachine
{
    public class DrinkMaker
    {
        private const string COFFEE = "C";
        private const string TEA = "T";
        private const string CHOCOLATE = "H";

        public string Coffee()
        {
            return COFFEE + "::";
        }

        public string CoffeeWithSugar()
        {
            return COFFEE + ":1:1";
        }

        public string CoffeeWithTwoSugar()
        {
            return COFFEE + ":2:1";
        }

        public object Tea()
        {
            return TEA + "::";
        }

        public object TeaWithSugar()
        {
            return TEA + ":1:1";
        }

        public object TeaWithTwoSugar()
        {
            return TEA + ":2:1";
        }

        public object Chocolate()
        {
            return CHOCOLATE + "::";
        }

        public object ChocolateWithSugar()
        {
            return CHOCOLATE + ":1:1";
        }

        public object ChocolateWithTwoSugar()
        {
            return CHOCOLATE + ":2:1";
        }
    }
}