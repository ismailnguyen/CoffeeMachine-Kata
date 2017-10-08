using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTest
{
    public class DrinkMakerTest
    {
        [Test]
        public void Should_Make_Coffee_Without_Sugar_Without_Stick()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.Coffee()).IsEqualTo("C::");
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
    }
}
