namespace CoffeeMachine
{
    public class DrinkMakerProtocol : IDrinkMakerProtocol
    {
        private string drinkCode;
        private int sugarQuantity;

        public string BuildMessage()
        {
            if (drinkCode == null)
            {
                return string.Empty;
            }

            if (sugarQuantity == 0)
            {
                return $"{drinkCode}::";
            }

            return $"{drinkCode}:{sugarQuantity}:1";
        }

        public void SetDrinkCode(string drinkCode)
        {
            this.drinkCode = drinkCode;
        }

        public void SetSugarQuantity(int sugarQuantity)
        {
            this.sugarQuantity = sugarQuantity;
        }
    }
}