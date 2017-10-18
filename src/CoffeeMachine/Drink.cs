namespace CoffeeMachine
{
    public class Drink
    {
        private const string FORMAT_DRINK_WITH_SUGAR = "{0}:{1}:1";
        private const string FORMAT_DRINK_WITHOUT_SUGAR = "{0}::";

        private string drinkCode;
        public double Price { get; private set; }

        public Drink(string drinkCode, double price)
        {
            this.drinkCode = drinkCode;
            Price = price;
        }

        public string BuildCommand()
        {
            return string.Format(FORMAT_DRINK_WITHOUT_SUGAR, drinkCode);
        }

        public string BuildCommandWithSugar(int sugarQuantity)
        {
            return string.Format(FORMAT_DRINK_WITH_SUGAR, drinkCode, sugarQuantity);
        }
    }
}