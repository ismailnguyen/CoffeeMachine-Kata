namespace CoffeeMachine
{
    public abstract class DrinkMaker
    {
        public double InsertedMoneyAmount { get; private set; }

        public void InsertMoney(double moneyAmount)
        {
            InsertedMoneyAmount += moneyAmount;
        }

        public double GetMissingMoneyAmount(double drinkPrice)
        {
            return drinkPrice - InsertedMoneyAmount;
        }

        public abstract string Make();
        public abstract string MakeWithSugar(int sugarQuantity = 1);

        public object ForwardMessage()
        {
            return "M:message-content";
        }
    }
}