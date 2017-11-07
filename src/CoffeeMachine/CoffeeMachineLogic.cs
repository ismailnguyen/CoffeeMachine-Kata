namespace CoffeeMachine
{
    public class CoffeeMachineLogic
    {
        private readonly IDrinkMakerProtocol drinkMakerProtocol;

        public CoffeeMachineLogic(IDrinkMakerProtocol drinkMakerProtocol)
        {
            this.drinkMakerProtocol = drinkMakerProtocol;
        }

        public string SendCommand(IDrinkOrder drinkOrder)
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