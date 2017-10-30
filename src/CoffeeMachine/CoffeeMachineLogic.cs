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

        public string SendCommand()
        {
            drinkMakerProtocol.BuildCommand();

            return "test";
        }
    }
}