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
            drinkMakerProtocol.Received().BuildCommand();
        }

        [TestCase("message-content")]
        public void ForwardMessage_Should_Call_BuildMessage_Of_DrinkMakerProtocol(string message)
        {
            // GIVEN
            IDrinkMakerProtocol drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();

            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            // WHEN
            string forwardedMessage = coffeeMachineLogic.ForwardMessage(message);

            // THEN
            drinkMakerProtocol.Received().BuildMessage(message);
        }
    }
}
