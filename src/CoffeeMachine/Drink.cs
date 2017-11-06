namespace CoffeeMachine
{
    public abstract class Drink : IDrink
    {
        private string code;
        private int sugarQuantity = 0;

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

        public int GetSugarQuantity()
        {
            return sugarQuantity;
        }
    }
}
