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
    }
}
