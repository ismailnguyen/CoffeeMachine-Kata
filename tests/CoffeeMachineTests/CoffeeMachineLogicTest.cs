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
    }
}
