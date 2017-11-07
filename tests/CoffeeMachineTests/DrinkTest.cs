using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTests
{
    class DrinkTest
    {
        [Test]
        public void AddSugar_Should_Add_Sugar_To_Drink()
        {
            // GIVEN
            IDrink drink = new Coffee();
            drink.AddSugar();

            // WHEN
            int sugarQuantity = drink.GetSugarQuantity();

            // THEN
            int expectedSugarQuantity = 1;
            Check.That(sugarQuantity).IsEqualTo(expectedSugarQuantity);
        }

        [Test]
        public void AddSugar_Should_Add_Two_Sugar_To_Drink()
        {
            // GIVEN
            IDrink drink = new Coffee();
            drink.AddSugar().AddSugar();

            // WHEN
            int sugarQuantity = drink.GetSugarQuantity();

            // THEN
            int expectedSugarQuantity = 2;
            Check.That(sugarQuantity).IsEqualTo(expectedSugarQuantity);
        }

        [Test]
        public void AddSugar_Should_Not_Add_More_Than_Two_Sugar_To_Drink()
        {
            // GIVEN
            IDrink drink = new Coffee();
            drink.AddSugar().AddSugar().AddSugar();

            // WHEN
            int sugarQuantity = drink.GetSugarQuantity();

            // THEN
            int expectedSugarQuantity = 2;
            Check.That(sugarQuantity).IsEqualTo(expectedSugarQuantity);
        }
    }
}
