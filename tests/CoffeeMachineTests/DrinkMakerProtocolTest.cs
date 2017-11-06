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

        [TestCase("C", "C::")]
        [TestCase("C", "C::")]
        [TestCase("H", "H::")]
        public void Should_Build_Message_For_Drink(string drinkCode, string expectedMessage)
        {
            // GIVEN
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();
            drinkMakerProtocol.SetDrinkCode(drinkCode);

            // WHEN
            string message = drinkMakerProtocol.BuildMessage();

            // THEN
            Check.That(message).IsEqualTo(expectedMessage);
        }
    }
}
