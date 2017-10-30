using CoffeeMachine;
using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachineTests
{
    class CoffeeMachineLogicTest
    {
        [Test]
        public void SendCommand_Should_Not_Return_Empty_String()
        {
            // GIVEN
            IDrinkOrder drinkOrder = Substitute.For<IDrinkOrder>();
            IDrinkMakerProtocol drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();

            var coffeeMachineLogic = new CoffeeMachineLogic(drinkOrder, drinkMakerProtocol);

            // WHEN
            string command = coffeeMachineLogic.SendCommand();

            // THEN
            Check.That(command).IsNotNull().And.IsNotEmpty();
        }

        [Test]
        public void SendCommand_Should_Call_BuildCommand_Of_DrinkMakerProtocol()
        {
            // GIVEN
            IDrinkOrder drinkOrder = Substitute.For<IDrinkOrder>();
            IDrinkMakerProtocol drinkMakerProtocol = Substitute.For<IDrinkMakerProtocol>();

            var coffeeMachineLogic = new CoffeeMachineLogic(drinkOrder, drinkMakerProtocol);

            // WHEN
            coffeeMachineLogic.SendCommand();

            // THEN
            drinkMakerProtocol.Received().BuildCommand();
        }
    }
}
