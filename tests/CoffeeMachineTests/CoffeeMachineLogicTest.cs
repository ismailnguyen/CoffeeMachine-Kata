using CoffeeMachine;
using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachineTests
{
    class CoffeeMachineLogicTest
    {
        [Test]
        public void SendCommand_Should_Return_Empty_String()
        {
            // GIVEN
            var drinkOrder = Substitute.For<IDrinkOrder>();
            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();

            var coffeeMachineLogic = new CoffeeMachineLogic(drinkOrder, drinkMakerProtocol);

            // WHEN
            string command = coffeeMachineLogic.SendCommand();

            // THEN
            Check.That(command).IsEmpty();
        }

        [Test]
        public void SendCommand_Should_Call_BuildCommand_Of_DrinkMakerProtocol()
        {
            // GIVEN
            var drinkOrder = Substitute.For<IDrinkOrder>();
            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();

            var coffeeMachineLogic = new CoffeeMachineLogic(drinkOrder, drinkMakerProtocol);

            // WHEN
            coffeeMachineLogic.SendCommand();

            // THEN
            drinkMakerProtocol.Received().BuildMessage();
        }

        [TestCase("foo")]
        [TestCase("bar")]
        [TestCase("baz")]
        public void SendCommand_Should_Send_Command_From_DrinkMakerProtocol(string expectedCommand)
        {
            // GIVEN
            var drinkOrder = Substitute.For<IDrinkOrder>();

            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();
            drinkMakerProtocol.BuildMessage().Returns(expectedCommand);

            var coffeeMachineLogic = new CoffeeMachineLogic(drinkOrder, drinkMakerProtocol);

            // WHEN
            var command = coffeeMachineLogic.SendCommand();

            // THEN
            Check.That(command).IsEqualTo(expectedCommand);
        }

        [Test]
        public void SendCommand_Should_Call_GetDrink_From_DrinkOrder()
        {
            // GIVEN
            var drinkOrder = Substitute.For<IDrinkOrder>();

            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();

            var coffeeMachineLogic = new CoffeeMachineLogic(drinkOrder, drinkMakerProtocol);

            // WHEN
            var command = coffeeMachineLogic.SendCommand();

            // THEN
            drinkOrder.Received().GetDrink();
        }
    }
}
