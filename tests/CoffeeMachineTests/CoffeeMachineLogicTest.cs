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
            drinkOrder.GetPrice().Returns(0);

            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();
            var cashRegister = Substitute.For<ICashRegister>();
            cashRegister.IsInsertedAmountLessThan(0).Returns(true);

            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol, cashRegister);

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
            var cashRegister = Substitute.For<ICashRegister>();
            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol, cashRegister);

            coffeeMachineLogic.InsertMoney(insertedMoney);

            // WHEN
            coffeeMachineLogic.SendCommand(drinkOrder);

            // THEN
            drinkMakerProtocol.DidNotReceive().BuildCommand(drinkOrder);
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

            var cashRegister = Substitute.For<ICashRegister>();
            cashRegister.IsInsertedAmountLessThan(orderPrice).Returns(false);
            cashRegister.DifferenceWith(orderPrice).Returns(orderPrice - insertedMoney);

            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol, cashRegister);

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

            var cashRegister = Substitute.For<ICashRegister>();
            cashRegister.IsInsertedAmountLessThan(orderPrice).Returns(true);

            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol, cashRegister);

            // WHEN
            coffeeMachineLogic.SendCommand(drinkOrder);

            // THEN
            drinkMakerProtocol.Received().BuildCommand(drinkOrder);
        }

        [TestCase("message-content")]
        [TestCase("Foo")]
        [TestCase("Bar")]
        public void ForwardMessage_Should_Call_BuildMessage_Of_DrinkMakerProtocol(string message)
        {
            // GIVEN
            var drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();
            var cashRegister = Substitute.For<ICashRegister>();

            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol, cashRegister);

            // WHEN

            //TODO: Forward message should be on DrinkMaker
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

            var cashRegister = Substitute.For<ICashRegister>();
            var coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol, cashRegister);

            // WHEN
            string forwardedMessage = coffeeMachineLogic.ForwardMessage(message);

            // THEN
            Check.That(forwardedMessage).IsEqualTo(expectedMessage);
        }
    }
}
