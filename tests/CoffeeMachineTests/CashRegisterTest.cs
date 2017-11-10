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
            bool haveSufficientMoneyFor = cashRegister.IsInsertedAmountLessThan(minimumNeededMoney);

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
            bool haveSufficientMoneyFor = cashRegister.IsInsertedAmountLessThan(minimumNeededMoney);

            // THEN
            Check.That(haveSufficientMoneyFor).IsFalse();
        }

        [TestCase(5, 2, 3)]
        [TestCase(30, 5, 25)]
        [TestCase(1.20, 0.50, 0.70)]
        public void AmountDifferenceWith_Should_Calcul_Difference_Between_Given_Amount_And_Inserted_Money(double amountToCheck, double insertedMoney, double expectedAmountDifference)
        {
            // GIVEN
            CashRegister cashRegister = new CashRegister();
            cashRegister.Add(insertedMoney);

            // WHEN
            double amountDifference = cashRegister.DifferenceWith(amountToCheck);

            // THEN
            Check.That(amountDifference).IsEqualTo(expectedAmountDifference);
        }
    }
}
