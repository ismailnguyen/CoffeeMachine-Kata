namespace CoffeeMachine
{
    public class CashRegister
    {
        private double insertedMoney = 0;

        public void Add(double money)
        {
            insertedMoney += money;
        }

        public bool HaveSufficientMoneyFor(double minimumNeededMoney)
        {
            return insertedMoney >= minimumNeededMoney;
        }
    }
}