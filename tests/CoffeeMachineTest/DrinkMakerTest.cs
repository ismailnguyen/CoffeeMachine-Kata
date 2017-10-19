using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTest
{
    internal class DrinkMakerTest
    {
        [Test]
        public void Should_Forward_Message_To_Interface()
        {
            var drinkMaker = new CoffeeMaker();

            Check.That(drinkMaker.ForwardMessage()).IsEqualTo("M:message-content");
        }
    }
}
