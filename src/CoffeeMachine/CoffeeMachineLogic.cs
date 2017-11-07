using System;

namespace CoffeeMachine
{
    public class CoffeeMachineLogic
    {
        private readonly IDrinkOrder drinkOrder;
        private readonly IDrinkMakerProtocol drinkMakerProtocol;

        public CoffeeMachineLogic(IDrinkOrder drinkOrder, IDrinkMakerProtocol drinkMakerProtocol)
        {
            this.drinkOrder = drinkOrder;
            this.drinkMakerProtocol = drinkMakerProtocol;
        }

        public CoffeeMachineLogic(IDrinkMakerProtocol drinkMakerProtocol)
        {
            this.drinkMakerProtocol = drinkMakerProtocol;
        }

        public string SendCommand()
        {
            var drinkCode = drinkOrder.GetDrinkCode();
            var sugarQuantity = drinkOrder.GetSugarQuantity();

            drinkMakerProtocol.SetDrinkCode(drinkCode);
            drinkMakerProtocol.SetSugarQuantity(sugarQuantity);

            return drinkMakerProtocol.BuildCommand();
        }

        public string ForwardMessage(string message)
        {
            return drinkMakerProtocol.BuildMessage(message);
        }
    }
}