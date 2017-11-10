using CoffeeMachine;
using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachineTests
{
    class DrinkMakerProtocolTest
    {
        [Test]
        public void BuildMessage_Should_Build_Empty_Message()
        {
            // GIVEN
            IDrinkOrder drinkOrder = Substitute.For<IDrinkOrder>();
            drinkOrder.GetDrinkCode().Returns(string.Empty);

            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            // WHEN
            string message = drinkMakerProtocol.BuildCommand(drinkOrder);

            // THEN
            Check.That(message).IsEmpty();
        }

        [TestCase("C", "C::")]
        [TestCase("T", "T::")]
        [TestCase("H", "H::")]
        public void BuildMessage_Should_Build_Message_For_Drink(string drinkCode, string expectedMessage)
        {
            // GIVEN
            IDrinkOrder drinkOrder = Substitute.For<IDrinkOrder>();
            drinkOrder.GetDrinkCode().Returns(drinkCode);

            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            // WHEN
            string message = drinkMakerProtocol.BuildCommand(drinkOrder);

            // THEN
            Check.That(message).IsEqualTo(expectedMessage);
        }

        [TestCase("C", 0, "C::")]
        [TestCase("T", 1, "T:1:1")]
        [TestCase("H", 3, "H:3:1")]
        public void BuildMessage_Should_Build_Message_For_Drink_With_Sugar_Quantity(string drinkCode, int sugarQuantity, string expectedMessage)
        {
            // GIVEN
            IDrinkOrder drinkOrder = Substitute.For<IDrinkOrder>();
            drinkOrder.GetDrinkCode().Returns(drinkCode);
            drinkOrder.GetSugarQuantity().Returns(sugarQuantity);

            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            // WHEN
            string message = drinkMakerProtocol.BuildCommand(drinkOrder);

            // THEN
            Check.That(message).IsEqualTo(expectedMessage);
        }
    }
}
