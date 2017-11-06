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
            if (drinkOrder.GetDrink() is Coffee)
            {
                return "C::";
            }

            return drinkMakerProtocol.BuildMessage();
        }
    }
}