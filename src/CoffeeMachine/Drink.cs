namespace CoffeeMachine
{
    public abstract class Drink : IDrink
    {
        private string code;
        private int sugarQuantity = 0;
        private double price;

        protected Drink(string code)
        {
            this.code = code;
        }

        public IDrink AddSugar()
        {
            if (sugarQuantity >= 2)
            {
                return this;
            }

            sugarQuantity++;

            return this;
        }

        public string GetCode()
        {
            return code;
        }

        public double GetPrice()
        {
            return price;
        }

        public int GetSugarQuantity()
        {
            return sugarQuantity;
        }
    }
}
