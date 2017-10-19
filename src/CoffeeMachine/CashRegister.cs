namespace CoffeeMachine
{
    public class CashRegister
    {
        private double insertedMoneyAmount;

        public void InsertMoney(double moneyAmount)
        {
            insertedMoneyAmount += moneyAmount;
        }

        public double CompareWithInsertedMoney(double amount)
        {
            return amount - insertedMoneyAmount;
        }

        public bool IsInsertedMoneyLessThan(double amount)
        {
            return insertedMoneyAmount < amount;
        }
    }
}
