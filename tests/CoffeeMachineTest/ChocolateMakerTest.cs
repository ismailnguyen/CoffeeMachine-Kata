using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTest
{
    public class ChocolateMakerTest
    {
        [TestCase(0.5)]
        [TestCase(0.6)]
        [TestCase(2)]
        public void Should_Make_Chocolate_Without_Sugar_Without_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new ChocolateMaker();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("H::");
        }

        [TestCase(0, "M:0,50")]
        [TestCase(0.1, "M:0,40")]
        [TestCase(0.4, "M:0,10")]
        public void Should_Make_Chocolate_Without_Sugar_Without_Stick_With_Insufficient_Money(double moneyAmountToInsert, string expectedMissingMoneyAmount)
        {
            var drinkMaker = new ChocolateMaker();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo(expectedMissingMoneyAmount);
        }

        [TestCase(0.5)]
        [TestCase(0.6)]
        [TestCase(2)]
        public void Should_Make_Chocolate_With_Sugar_With_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new ChocolateMaker();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("H:1:1");
        }

        [TestCase(0, "M:0,50")]
        [TestCase(0.1, "M:0,40")]
        [TestCase(0.4, "M:0,10")]
        public void Should_Make_Chocolate_With_Sugar_With_Stick_With_Insufficient_Money(double moneyAmountToInsert, string expectedMissingMoneyAmount)
        {
            var drinkMaker = new ChocolateMaker();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo(expectedMissingMoneyAmount);
        }

        [TestCase(0.5)]
        [TestCase(0.6)]
        [TestCase(2)]
        public void Should_Make_Chocolate_With_Two_Sugar_With_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new ChocolateMaker();
            drinkMaker.AddSugar();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("H:2:1");
        }

        [TestCase(0, "M:0,50")]
        [TestCase(0.1, "M:0,40")]
        [TestCase(0.4, "M:0,10")]
        public void Should_Make_Chocolate_With_Two_Sugar_With_Stick_With_Insufficient_Money(double moneyAmountToInsert, string expectedMissingMoneyAmount)
        {
            var drinkMaker = new ChocolateMaker();
            drinkMaker.AddSugar();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo(expectedMissingMoneyAmount);
        }

        [TestCase(0.5)]
        [TestCase(0.6)]
        [TestCase(1)]
        public void Should_Make_Extra_Hot_Chocolate_With_Two_Sugar_With_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new ChocolateMaker();
            drinkMaker.AddSugar();
            drinkMaker.AddSugar();
            drinkMaker.SetExtraHot();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("Hh:2:1");
        }
    }
}
