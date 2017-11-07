using CoffeeMachine;
using NFluent;
using NUnit.Framework;
namespace CoffeeMachineTests
{
    class CoffeeMachineAcceptanceTest
    {
        [Test]
        public void SendMessage_Should_Send_Correct_Instructions_For_Coffee_Order()
        {
            // GIVEN
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();
            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            IDrink drink = new Coffee();
            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            var price = drinkOrder.GetPrice();
            coffeeMachineLogic.InsertMoney(price);

            // WHEN
            string command = coffeeMachineLogic.SendCommand(drinkOrder);

            // THEN
            Check.That(command).IsEqualTo("C::");
        }

        [Test]
        public void SendMessage_Should_Send_Correct_Instructions_For_Tea_With_Sugar_Order()
        {
            // GIVEN
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();
            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            IDrink drink = new Tea();
            drink.AddSugar();
            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            var price = drinkOrder.GetPrice();
            coffeeMachineLogic.InsertMoney(price);

            // WHEN
            string command = coffeeMachineLogic.SendCommand(drinkOrder);

            // THEN
            Check.That(command).IsEqualTo("T:1:1");
        }

        [Test]
        public void SendMessage_Should_Send_Correct_Instructions_For_Chocolate_With_Two_Sugar_Order()
        {
            // GIVEN
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();
            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            IDrink drink = new Chocolate();
            drink.AddSugar().AddSugar();
            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            var price = drinkOrder.GetPrice();
            coffeeMachineLogic.InsertMoney(price);

            // WHEN
            string command = coffeeMachineLogic.SendCommand(drinkOrder);

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

        [Test]
        public void SendMessage_Should_Send_Correct_Instructions_For_Orange_Juice_Order()
        {
            // GIVEN
            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();
            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkMakerProtocol);

            IDrink drink = new OrangeJuice();
            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            var price = drinkOrder.GetPrice();
            coffeeMachineLogic.InsertMoney(price);

            // WHEN
            string command = coffeeMachineLogic.SendCommand(drinkOrder);

            // THEN
            Check.That(command).IsEqualTo("O::");
        }
    }
}
