namespace CoffeeMachine
{
    public class CoffeeMachineLogic
    {
        private readonly IDrinkMakerProtocol drinkMakerProtocol;
        private readonly CashRegister cashRegister;

        public CoffeeMachineLogic(IDrinkMakerProtocol drinkMakerProtocol)
        {
            this.drinkMakerProtocol = drinkMakerProtocol;
            cashRegister = new CashRegister();
        }

        public string SendCommand(IDrinkOrder drinkOrder)
        {
            if (!isEnoughPrice(drinkOrder.GetPrice()))
            {
                return "";
            }

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

        private bool isEnoughPrice(double drinkPrice)
        {
            return cashRegister.HaveSufficientMoneyFor(drinkPrice);
        }

        public void InsertMoney(double price)
        {
            cashRegister.Add(price);
        }
    }
}