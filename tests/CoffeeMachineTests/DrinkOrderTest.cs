using CoffeeMachine;
using NSubstitute;
using NUnit.Framework;

namespace CoffeeMachineTests
{
    class DrinkOrderTest
    {
        [Test]
        public void GetDrinkCode_Should_Call_GetCode_Of_Drink()
        {
            // GIVEN
            var drink = Substitute.For<IDrink>();
            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            // WHEN
            drinkOrder.GetDrinkCode();

            // THEN
            drink.Received().GetCode();
        }
    }
}
