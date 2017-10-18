namespace CoffeeMachine
{
    public abstract class DrinkMaker
    {
        protected Drink Drink { get; set; }
        private CashRegister cashRegister = new CashRegister();

        public void InsertMoney(double moneyAmount)
        {
            cashRegister.InsertMoney(moneyAmount);
        }

        private double calculMissingMoneyAmount()
        {
            return cashRegister.CompareWithInsertedMoney(Drink.Price);
        }

        private string showInsufficientMoneyMessage()
        {
            return string.Format("M:{0:0.00}", calculMissingMoneyAmount());
        }

        public string Make()
        {
            if (cashRegister.IsInsertedMoneyLessThan(Drink.Price))
            {
                return showInsufficientMoneyMessage();
            }

            return Drink.BuildCommand();
        }

        public string MakeWithSugar(int sugarQuantity = 1)
        {
            if (cashRegister.IsInsertedMoneyLessThan(Drink.Price))
            {
                return showInsufficientMoneyMessage();
            }

            return Drink.BuildCommandWithSugar(sugarQuantity);
        }

        public object ForwardMessage()
        {
            return "M:message-content";
        }
    }
}