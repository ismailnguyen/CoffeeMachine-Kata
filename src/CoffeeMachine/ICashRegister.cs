namespace CoffeeMachine
{
    public interface ICashRegister
    {
        void Add(double money);

        bool IsInsertedAmountLessThan(double minimumNeededMoney);

        double DifferenceWith(double amountToCheck);
    }
}