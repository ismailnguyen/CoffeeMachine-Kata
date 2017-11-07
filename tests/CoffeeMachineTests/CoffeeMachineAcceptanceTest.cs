using CoffeeMachine;
using NFluent;
using NUnit.Framework;
namespace CoffeeMachineTests
{
    class CoffeeMachineAcceptanceTest
    {
        [Test]
        public void Should_Send_Correct_Instructions_For_Coffee_Order()
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
        public void Should_Send_Correct_Instructions_For_Tea_With_Sugar_Order()
        {
            // GIVEN
            IDrink drink = new Tea();
            //drink.AddSugar();
            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            IDrinkMakerProtocol drinkMakerProtocol = new DrinkMakerProtocol();

            CoffeeMachineLogic coffeeMachineLogic = new CoffeeMachineLogic(drinkOrder, drinkMakerProtocol);

            // WHEN
            string command = coffeeMachineLogic.SendCommand();

            // THEN
            Check.That(command).IsEqualTo("T:1:1");
        }
    }
}
