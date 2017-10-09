using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTest
{
    public class DrinkMakerTest
    {
        [TestCase(0.6)]
        [TestCase(0.7)]
        [TestCase(2)]
        public void Should_Make_Coffee_Without_Sugar_Without_Stick_With_Enough_Money(double insertedMoneyAmount)
        {
            var drinkMaker = new DrinkMaker();

            drinkMaker.InsertMoney(insertedMoneyAmount);

            Check.That(drinkMaker.Coffee()).IsEqualTo("C::");
        }

        [TestCase(0, "M:0,60")]
        [TestCase(0.1, "M:0,50")]
        [TestCase(0.5, "M:0,10")]
        public void Should_Not_Make_Coffee_Without_Sugar_Without_Stick_With_Insufficient_Money(double insertedMoneyAmount, string missingMoneyAmount)
        {
            var drinkMaker = new DrinkMaker();

            drinkMaker.InsertMoney(insertedMoneyAmount);

            Check.That(drinkMaker.Coffee()).IsEqualTo(missingMoneyAmount);
        }

        [Test]
        public void Should_Make_Coffee_With_Sugar_With_Stick()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.CoffeeWithSugar()).IsEqualTo("C:1:1");
        }

        [Test]
        public void Should_Make_Coffee_With_Two_Sugar_With_Stick()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.CoffeeWithSugar(2)).IsEqualTo("C:2:1");
        }

        [TestCase(0, "M:0,40")]
        [TestCase(0.1, "M:0,30")]
        [TestCase(0.3, "M:0,10")]
        public void Should_Make_Tea_Without_Sugar_Without_Stick_With_Insufficient_Money(double insertedMoneyAmount, string missingMoneyAmount)
        {
            var drinkMaker = new DrinkMaker();

            drinkMaker.InsertMoney(insertedMoneyAmount);

            Check.That(drinkMaker.Tea()).IsEqualTo(missingMoneyAmount);
        }

        [Test]
        public void Should_Make_Tea_With_Sugar_With_Stick()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.TeaWithSugar()).IsEqualTo("T:1:1");
        }

        [Test]
        public void Should_Make_Tea_With_Two_Sugar_With_Stick()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.TeaWithSugar(2)).IsEqualTo("T:2:1");
        }

        [Test]
        public void Should_Make_Chocolate_Without_Sugar_Without_Stick()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.Chocolate()).IsEqualTo("H::");
        }

        [Test]
        public void Should_Make_Chocolate_With_Sugar_With_Stick()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.ChocolateWithSugar()).IsEqualTo("H:1:1");
        }

        [Test]
        public void Should_Make_Chocolate_With_Two_Sugar_With_Stick()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.ChocolateWithSugar(2)).IsEqualTo("H:2:1");
        }

        [Test]
        public void Should_Forward_Message_To_Interface()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.ForwardMessage()).IsEqualTo("M:message-content");
        }
    }
}
