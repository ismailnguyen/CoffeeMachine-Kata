using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTest
{
    public class OrangeJuiceMakerTest
    {
        [TestCase(0.6)]
        [TestCase(0.7)]
        [TestCase(2)]
        public void Should_Make_Orange_Juice_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new OrangeJuiceMaker();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("O::");
        }

        [TestCase(0, "M:0,60")]
        [TestCase(0.1, "M:0,50")]
        [TestCase(0.5, "M:0,10")]
        public void Should_Not_Make_Orange_Juice_With_Insufficient_Money(double moneyAmountToInsert, string expectedMissingMoneyAmount)
        {
            var drinkMaker = new OrangeJuiceMaker();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo(expectedMissingMoneyAmount);
        }
    }
}