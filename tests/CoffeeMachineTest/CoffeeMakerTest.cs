using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTest
{
    public class CoffeeMakerTest
    {
        [TestCase(0.6)]
        [TestCase(0.7)]
        [TestCase(2)]
        public void Should_Make_Coffee_Without_Sugar_Without_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new CoffeeMaker();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("C::");
        }

        [TestCase(0, "M:0,60")]
        [TestCase(0.1, "M:0,50")]
        [TestCase(0.5, "M:0,10")]
        public void Should_Not_Make_Coffee_Without_Sugar_Without_Stick_With_Insufficient_Money(double moneyAmountToInsert, string expectedMissingMoneyAmount)
        {
            var drinkMaker = new CoffeeMaker();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo(expectedMissingMoneyAmount);
        }

        [TestCase(0.6)]
        [TestCase(0.7)]
        [TestCase(2)]
        public void Should_Make_Coffee_With_Sugar_With_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new CoffeeMaker();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("C:1:1");
        }

        [TestCase(0, "M:0,60")]
        [TestCase(0.1, "M:0,50")]
        [TestCase(0.5, "M:0,10")]
        public void Should_Make_Coffee_With_Sugar_With_Stick_With_Insufficient_Money(double moneyAmountToInsert, string expectedMissingMoneyAmount)
        {
            var drinkMaker = new CoffeeMaker();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo(expectedMissingMoneyAmount);
        }

        [TestCase(0.6)]
        [TestCase(0.7)]
        [TestCase(2)]
        public void Should_Make_Coffee_With_Two_Sugar_With_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new CoffeeMaker();
            drinkMaker.AddSugar();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("C:2:1");
        }

        [TestCase(0, "M:0,60")]
        [TestCase(0.1, "M:0,50")]
        [TestCase(0.5, "M:0,10")]
        public void Should_Make_Coffee_With_Two_Sugar_With_Stick_With_Insufficient_Money(double moneyAmountToInsert, string expectedMissingMoneyAmount)
        {
            var drinkMaker = new CoffeeMaker();
            drinkMaker.AddSugar();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo(expectedMissingMoneyAmount);
        }

        [TestCase(0.6)]
        [TestCase(0.7)]
        [TestCase(1)]
        public void Should_Make_Extra_Hot_Coffee_With_Two_Sugar_With_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new CoffeeMaker();
            drinkMaker.AddSugar();
            drinkMaker.AddSugar();
            drinkMaker.SetExtraHot();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("Ch:2:1");
        }
    }
}