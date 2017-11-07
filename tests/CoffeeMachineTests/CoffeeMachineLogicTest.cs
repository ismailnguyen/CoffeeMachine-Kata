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
            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();
            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            var drinkOrder = Substitute.For<IDrinkOrder>();

            // WHEN
            string command = coffeeMachineLogic.SendCommand(drinkOrder);

            // THEN
            Check.That(command).IsEmpty();
        }

        [Test]
        public void SendCommand_Should_Not_Call_BuildCommand_Of_DrinkMakerProtocol_With_Insufficient_Money_Inserted()
        {
            // GIVEN
            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();
            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            var drinkOrder = Substitute.For<IDrinkOrder>();

            coffeeMachineLogic.InsertMoney(0);

            // WHEN
            coffeeMachineLogic.SendCommand(drinkOrder);

            // THEN
            drinkMakerProtocol.DidNotReceive().BuildCommand();
        }

        [TestCase("message-content")]
        [TestCase("Foo")]
        [TestCase("Bar")]
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

        [TestCase("message-content", "M:message-content")]
        [TestCase("Foo", "M:Foo")]
        [TestCase("Bar", "M:Bar")]
        public void ForwardMessage_Should_Return_Correct_Instruction_For_Message(string message, string expectedMessage)
        {
            // GIVEN
            IDrinkMakerProtocol drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();
            drinkMakerProtocol.BuildMessage(message).Returns(expectedMessage);

            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            // WHEN
            string forwardedMessage = coffeeMachineLogic.ForwardMessage(message);

            // THEN
            Check.That(forwardedMessage).IsEqualTo(expectedMessage);
        }
    }
}
