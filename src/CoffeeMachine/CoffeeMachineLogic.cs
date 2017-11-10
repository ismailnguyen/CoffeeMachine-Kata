namespace CoffeeMachine
{
    public class CoffeeMachineLogic
    {
        private readonly IDrinkMakerProtocol drinkMakerProtocol;
        private readonly ICashRegister cashRegister;

        public CoffeeMachineLogic(IDrinkMakerProtocol drinkMakerProtocol, ICashRegister cashRegister)
        {
            this.drinkMakerProtocol = drinkMakerProtocol;
            this.cashRegister = cashRegister;
        }

        public string SendCommand(IDrinkOrder drinkOrder)
        {
            var drinkPrice = drinkOrder.GetPrice();

            if (!IsEnoughPrice(drinkPrice))
            {
                return SendInsufficientMoneyMessage(drinkPrice);
            }

            return drinkMakerProtocol.BuildCommand(drinkOrder);
        }

        private string SendInsufficientMoneyMessage(double drinkPrice)
        {
            double missingAmount = cashRegister.DifferenceWith(drinkPrice);

            return string.Format("M:{0:0.00}", missingAmount);
        }

        public string ForwardMessage(string message)
        {
            return drinkMakerProtocol.BuildMessage(message);
        }

        private bool IsEnoughPrice(double drinkPrice)
        {
            return cashRegister.IsInsertedAmountLessThan(drinkPrice);
        }

        public void InsertMoney(double price)
        {
            cashRegister.Add(price);
        }
    }
}