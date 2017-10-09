using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTest
{
    public class DrinkMakerTest
    {
        [Test]
        public void Should_Make_Coffee_Without_Sugar_Without_Stick_With_Enough_Money()
        {
            var drinkMaker = new DrinkMaker();

            drinkMaker.InsertMoney(0.6);

            Check.That(drinkMaker.Coffee()).IsEqualTo("C::");
        }

        [Test]
        public void Should_Not_Make_Coffee_Without_Sugar_Without_Stick_With_Insufficient_Money()
        {
            var drinkMaker = new DrinkMaker();

            drinkMaker.InsertMoney(0.1);

            Check.That(drinkMaker.Coffee()).IsEqualTo("M:0,50");
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

            Check.That(drinkMaker.CoffeeWithTwoSugar()).IsEqualTo("C:2:1");
        }

        [Test]
        public void Should_Make_Tea_Without_Sugar_Without_Stick()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.Tea()).IsEqualTo("T::");
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

            Check.That(drinkMaker.TeaWithTwoSugar()).IsEqualTo("T:2:1");
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

            Check.That(drinkMaker.ChocolateWithTwoSugar()).IsEqualTo("H:2:1");
        }

        [Test]
        public void Should_Forward_Message_To_Interface()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.ForwardMessage()).IsEqualTo("M:message-content");
        }
    }
}
