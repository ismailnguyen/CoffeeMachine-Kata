using System;

namespace CoffeeMachine
{
    public class DrinkMakerProtocol : IDrinkMakerProtocol
    {
        public string BuildCommand(IDrinkOrder drinkOrder)
        {
            var drinkCode = drinkOrder.GetDrinkCode();
            var sugarQuantity = drinkOrder.GetSugarQuantity();

            if (string.IsNullOrEmpty(drinkCode))
            {
                return string.Empty;
            }

            if (sugarQuantity == 0)
            {
                return $"{drinkCode}::";
            }

            return $"{drinkCode}:{sugarQuantity}:1";
        }

        public string BuildMessage(string message)
        {
            return $"M:{message}";
        }
    }
}