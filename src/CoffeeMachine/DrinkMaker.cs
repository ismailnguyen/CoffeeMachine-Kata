namespace CoffeeMachine
{
    public abstract class DrinkMaker
    {
        protected Drink Drink { get; set; }
        private CashRegister cashRegister = new CashRegister();

        public void AddSugar()
        {
            Drink.AddSugar();
        }

        public void SetExtraHot()
        {
            Drink.SetExtraHot();
        }

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

        public object ForwardMessage()
        {
            return "M:message-content";
        }
    }
}