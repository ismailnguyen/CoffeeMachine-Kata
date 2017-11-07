using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTests
{
    class CashRegisterTest
    {
        [TestCase(2, 1)]
        [TestCase(99, 40)]
        public void HaveSufficientMoneyFor_Should_Return_True_When_Enough_Money_Is_Inserted(double insertedMoney, double minimumNeededMoney)
        {
            // GIVEN
            CashRegister cashRegister = new CashRegister();
            cashRegister.Add(insertedMoney);

            // WHEN
            bool haveSufficientMoneyFor = cashRegister.HaveSufficientMoneyFor(minimumNeededMoney);

            // THEN
            Check.That(haveSufficientMoneyFor).IsTrue();
        }

        [TestCase(1, 2)]
        [TestCase(23, 40)]
        public void HaveSufficientMoneyFor_Should_Return_False_When_Enough_Money_Is_Inserted(double insertedMoney, double minimumNeededMoney)
        {
            // GIVEN
            CashRegister cashRegister = new CashRegister();
            cashRegister.Add(insertedMoney);

            // WHEN
            bool haveSufficientMoneyFor = cashRegister.HaveSufficientMoneyFor(minimumNeededMoney);

            // THEN
            Check.That(haveSufficientMoneyFor).IsFalse();
        }
    }
}
