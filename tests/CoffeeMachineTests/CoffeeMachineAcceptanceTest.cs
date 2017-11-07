using CoffeeMachine;
using NFluent;
using NSubstitute;
using NUnit.Framework;
namespace CoffeeMachineTests
{
    class CoffeeMachineAcceptanceTest
    {
        [Test]
        public void SendMessage_Should_Send_Correct_Instructions_For_Coffee_Order()
        {
            // GIVEN
            IDrink drink = new Coffee();
            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkOrder, drinkMakerProtocol);

            // WHEN
            string command = coffeeMachineLogic.SendCommand();

            // THEN
            Check.That(command).IsEqualTo("C::");
        }

        [Test]
        public void SendMessage_Should_Send_Correct_Instructions_For_Tea_With_Sugar_Order()
        {
            // GIVEN
            IDrink drink = new Tea();
            drink.AddSugar();
            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkOrder, drinkMakerProtocol);

            // WHEN
            string command = coffeeMachineLogic.SendCommand();

            // THEN
            Check.That(command).IsEqualTo("T:1:1");
        }

        [Test]
        public void SendMessage_Should_Send_Correct_Instructions_For_Chocolate_With_Two_Sugar_Order()
        {
            // GIVEN
            IDrink drink = new Chocolate();
            drink.AddSugar().AddSugar();
            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkOrder, drinkMakerProtocol);

            // WHEN
            string command = coffeeMachineLogic.SendCommand();

            // THEN
            Check.That(command).IsEqualTo("H:2:1");
        }

        [TestCase("message-content", "M:message-content")]
        [TestCase("Foo", "M:Foo")]
        [TestCase("Bar", "M:Bar")]
        public void ForwardMessage_Should_Forward_Any_Message_Received(string message, string expectedMessage)
        {
            // GIVEN
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            // WHEN
            string forwardedMessage = coffeeMachineLogic.ForwardMessage(message);

            // THEN
            Check.That(forwardedMessage).IsEqualTo(expectedMessage);
        }
    }
}
