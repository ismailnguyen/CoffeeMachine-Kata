namespace CoffeeMachine
{
    public abstract class Drink
    {
        private string code;
        private double price;

        protected Drink(string code, double price)
        {
            this.code = code;
            this.price = price;
        }

        public string GetCode()
        {
            return code;
        }

        public double GetPrice()
        {
            return price;
        }
    }
}