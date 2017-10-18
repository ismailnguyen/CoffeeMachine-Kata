namespace CoffeeMachine
{
    public class Drink
    {
        private const string COFFEE_CODE = "C";
        private const string TEA_CODE = "T";
        private const string CHOCOLATE_CODE = "H";
        private const string FORMAT_DRINK_WITH_SUGAR = "{0}:{1}:1";
        private const string FORMAT_DRINK_WITHOUT_SUGAR = "{0}::";

        internal static readonly Drink Coffee = new Drink(COFFEE_CODE, 0.60);
        internal static readonly Drink Tea = new Drink(TEA_CODE, 0.40);
        internal static readonly Drink Chocolate = new Drink(CHOCOLATE_CODE, 0.50);

        public string DrinkCode { get; private set; }
        public double Price { get; private set; }

        private Drink(string drinkCode)
        {
            DrinkCode = drinkCode;
        }

        private Drink(string drinkCode, double price)
        {
            DrinkCode = drinkCode;
            Price = price;
        }

        public string Make()
        {
            return string.Format(FORMAT_DRINK_WITHOUT_SUGAR, DrinkCode);
        }

        public string MakeWithSugar(int sugarQuantity)
        {
            return string.Format(FORMAT_DRINK_WITH_SUGAR, DrinkCode, sugarQuantity);
        }
    }
}