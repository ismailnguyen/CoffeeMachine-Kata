using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTest
{
    public class TeaMakerTest
    {
        [TestCase(0.4)]
        [TestCase(0.6)]
        [TestCase(1)]
        public void Should_Make_Tea_Without_Sugar_Without_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new TeaMaker();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("T::");
        }

        [TestCase(0, "M:0,40")]
        [TestCase(0.1, "M:0,30")]
        [TestCase(0.3, "M:0,10")]
        public void Should_Not_Make_Tea_Without_Sugar_Without_Stick_With_Insufficient_Money(double moneyAmountToInsert, string expectedMissingMoneyAmount)
        {
            var drinkMaker = new TeaMaker();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo(expectedMissingMoneyAmount);
        }

        [TestCase(0.4)]
        [TestCase(0.6)]
        [TestCase(1)]
        public void Should_Make_Tea_With_Sugar_With_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new TeaMaker();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("T:1:1");
        }

        [TestCase(0, "M:0,40")]
        [TestCase(0.1, "M:0,30")]
        [TestCase(0.3, "M:0,10")]
        public void Should_Not_Make_Tea_With_Sugar_With_Stick_With_Insufficient_Money(double moneyAmountToInsert, string expectedMissingMoneyAmount)
        {
            var drinkMaker = new TeaMaker();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo(expectedMissingMoneyAmount);
        }

        [TestCase(0.4)]
        [TestCase(0.6)]
        [TestCase(1)]
        public void Should_Make_Tea_With_Two_Sugar_With_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new TeaMaker();
            drinkMaker.AddSugar();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("T:2:1");
        }

        [TestCase(0, "M:0,40")]
        [TestCase(0.1, "M:0,30")]
        [TestCase(0.3, "M:0,10")]
        public void Should_Not_Make_Tea_With_Two_Sugar_With_Stick_With_Insufficient_Money(double moneyAmountToInsert, string expectedMissingMoneyAmount)
        {
            var drinkMaker = new TeaMaker();
            drinkMaker.AddSugar();
            drinkMaker.AddSugar();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo(expectedMissingMoneyAmount);
        }

        [TestCase(0.4)]
        [TestCase(0.6)]
        [TestCase(1)]
        public void Should_Make_Extra_Hot_Tea_With_Two_Sugar_With_Stick_With_Enough_Money(double moneyAmountToInsert)
        {
            var drinkMaker = new TeaMaker();
            drinkMaker.AddSugar();
            drinkMaker.AddSugar();
            drinkMaker.SetExtraHot();

            drinkMaker.InsertMoney(moneyAmountToInsert);

            Check.That(drinkMaker.Make()).IsEqualTo("Th:2:1");
        }
    }
}
