using CoffeeMachine;
using NFluent;
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

        [TestCase("C")]
        public void GetDrinkCode_Should_Return_Code_From_Drink(string expectedDrinkCode)
        {
            // GIVEN
            var drink = Substitute.For<IDrink>();
            IDrinkOrder drinkOrder = new DrinkOrder(drink);
            drink.GetCode().Returns(expectedDrinkCode);

            // WHEN
            var drinkCode = drinkOrder.GetDrinkCode();

            // THEN
            Check.That(drinkCode).IsEqualTo(expectedDrinkCode);
        }
    }
}
