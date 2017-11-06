﻿using CoffeeMachine;
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
        public void AddSugar_Should_Add_Sugar_To_Drink(int expectedSugarQuantity)
        {
            // GIVEN
            var drink = Substitute.For<IDrink>();
            drink.GetSugarQuantity().Returns(expectedSugarQuantity);

            IDrinkOrder drinkOrder = new DrinkOrder(drink);

            // WHEN
            int sugarQuantity = drinkOrder.GetSugarQuantity();

            // THEN
            Check.That(sugarQuantity).IsEqualTo(expectedSugarQuantity);
        }
    }
}