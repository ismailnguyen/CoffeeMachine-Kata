using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTests
{
    class CashRegisterTest
    {
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(6)]
        public void Add_Should_Add_Money_In_CashRegister(double expectedMoney)
        {
            // GIVEN
            CashRegister cashRegister = new CashRegister();
            cashRegister.Add(expectedMoney);

            // WHEN
            double insertedMoney = cashRegister.GetAvailableMoney();

            // THEN
            Check.That(insertedMoney).IsEqualTo(expectedMoney);
        }
    }
}
