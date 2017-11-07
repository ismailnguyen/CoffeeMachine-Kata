using System;

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
            var drinkPrice = drinkOrder.GetPrice();

            if (!IsEnoughPrice(drinkPrice))
            {
                return SendInsufficientMoneyMessage(drinkPrice);
            }

            var drinkCode = drinkOrder.GetDrinkCode();
            var sugarQuantity = drinkOrder.GetSugarQuantity();

            drinkMakerProtocol.SetDrinkCode(drinkCode);
            drinkMakerProtocol.SetSugarQuantity(sugarQuantity);

            return drinkMakerProtocol.BuildCommand();
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