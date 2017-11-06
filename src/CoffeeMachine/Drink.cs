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

        public void AddSugar()
        {
            if (sugarQuantity >= 2)
            {
                return;
            }

            sugarQuantity++;
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
