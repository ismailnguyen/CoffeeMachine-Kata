namespace CoffeeMachine
{
    public class CashRegister : ICashRegister
    {
        private double insertedMoneyAmount = 0;

        public void Add(double money)
        {
            insertedMoneyAmount += money;
        }

        public bool IsInsertedAmountLessThan(double minimumNeededMoney)
        {
            return insertedMoneyAmount >= minimumNeededMoney;
        }

        public double DifferenceWith(double amountToCheck)
        {
            return amountToCheck - insertedMoneyAmount;
        }
    }
}