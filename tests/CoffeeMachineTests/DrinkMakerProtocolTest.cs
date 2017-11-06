using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTests
{
    class DrinkMakerProtocolTest
    {
        [Test]
        public void Should_Build_Empty_Message()
        {
            // GIVEN
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            // WHEN
            string message = drinkMakerProtocol.BuildMessage();

            // THEN
            Check.That(message).IsEmpty();
        }
    }
}
