using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTest
{
    public class DrinkMakerTest
    {
        [Test]
        public void Should_Make_Coffee_Without_Sugar()
        {
            var drinkMaker = new DrinkMaker();

            Check.That(drinkMaker.MakeCoffee()).IsEqualTo("C::");
        }
    }
}
