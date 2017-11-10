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
        [TestCase("H")]
        [TestCase("T")]
        public void GetDrinkCode_Should_Return_Code_From_Drink(string expectedDrinkCode)
        {
            // GIVEN
            var drink = Substitute.For<IDrink>();
            drink.GetCode().Returns(expectedDrinkCode);

            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            // WHEN
            var drinkCode = drinkOrder.GetDrinkCode();

            // THEN
            Check.That(drinkCode).IsEqualTo(expectedDrinkCode);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetSugarQuantity_Return_Sugar_Quantity_Of_HotDrink(int expectedSugarQuantity)
        {
            // GIVEN
            var drink = Substitute.For<IHotDrink>();
            drink.GetSugarQuantity().Returns(expectedSugarQuantity);

            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            // WHEN
            int sugarQuantity = drinkOrder.GetSugarQuantity();

            // THEN
            Check.That(sugarQuantity).IsEqualTo(expectedSugarQuantity);
        }

        [TestCase(0.2)]
        [TestCase(1)]
        [TestCase(34)]
        public void GetPrice_Should_Return_Price_Of_Drink(double expectedPrice)
        {
            // GIVEN
            IDrink drink = Substitute.For<IDrink>();
            drink.GetPrice().Returns(expectedPrice);

            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            // WHEN
            double orderPrice = drinkOrder.GetPrice();

            // THEN
            Check.That(orderPrice).IsEqualTo(expectedPrice);
        }
    }
}
