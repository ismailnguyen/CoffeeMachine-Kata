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

        [TestCase(3, 1)]
        [TestCase(1, 0)]
        [TestCase(4, 3)]
        public void SendCommand_Should_Not_Call_BuildCommand_Of_DrinkMakerProtocol_With_Insufficient_Money_Inserted(double orderPrice, double insertedMoney)
        {
            // GIVEN
            var drinkOrder = Substitute.For<IDrinkOrder>();
            drinkOrder.GetPrice().Returns(orderPrice);

            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();
            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            coffeeMachineLogic.InsertMoney(insertedMoney);

            // WHEN
            coffeeMachineLogic.SendCommand(drinkOrder);

            // THEN
            drinkMakerProtocol.DidNotReceive().BuildCommand();
        }

        [TestCase(3, 1, "M:2.00")]
        [TestCase(0.20, 0, "M:0.20")]
        [TestCase(4.5, 3, "M:1.50")]
        public void SendCommand_Should_Return_Missing_Money_Amount_With_Insufficient_Money_Inserted(double orderPrice, double insertedMoney, string expectedMessage)
        {
            // GIVEN
            var drinkOrder = Substitute.For<IDrinkOrder>();
            drinkOrder.GetPrice().Returns(orderPrice);

            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();
            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            coffeeMachineLogic.InsertMoney(insertedMoney);

            // WHEN
            string command = coffeeMachineLogic.SendCommand(drinkOrder);

            // THEN
            Check.That(command).IsEqualTo(expectedMessage);
        }

        [TestCase(1, 3)]
        [TestCase(7, 8)]
        [TestCase(4, 4)]
        public void SendCommand_Should_Call_BuildCommand_Of_DrinkMakerProtocol_With_Enough_Money_Inserted(double orderPrice, double insertedMoney)
        {
            // GIVEN
            var drinkOrder = Substitute.For<IDrinkOrder>();
            drinkOrder.GetPrice().Returns(orderPrice);

            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();
            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            coffeeMachineLogic.InsertMoney(insertedMoney);

            // WHEN
            coffeeMachineLogic.SendCommand(drinkOrder);

            // THEN
            drinkMakerProtocol.Received().BuildCommand();
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
