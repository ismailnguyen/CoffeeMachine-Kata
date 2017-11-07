namespace CoffeeMachine
{
    public class CashRegister
    {
        private double money = 0;

        public double GetAvailableMoney()
        {
            return money;
        }

        public void Add(double money)
        {
            this.money += money;
        }
    }
}