using System;

namespace CoffeeMachine
{
    public class DrinkMakerProtocol : IDrinkMakerProtocol
    {
        private string drinkCode;

        public string BuildMessage()
        {
            if (drinkCode == null)
            {
                return string.Empty;
            }

            return $"{drinkCode}::";
        }

        public void SetDrinkCode(string drinkCode)
        {
            this.drinkCode = drinkCode;
        }
    }
}