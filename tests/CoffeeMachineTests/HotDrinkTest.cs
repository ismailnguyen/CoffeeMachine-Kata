using CoffeeMachine;
using NFluent;
using NUnit.Framework;

namespace CoffeeMachineTests
{
    class HotDrinkTest
    {
        [Test]
        public void AddSugar_Should_Add_Sugar_To_Drink()
        {
            // GIVEN
            HotDrink drink = new Coffee();
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
            HotDrink drink = new Coffee();
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
            HotDrink drink = new Coffee();
            drink.AddSugar().AddSugar().AddSugar();

            // WHEN
            int sugarQuantity = drink.GetSugarQuantity();

            // THEN
            int expectedSugarQuantity = 2;
            Check.That(sugarQuantity).IsEqualTo(expectedSugarQuantity);
        }

        [Test]
        public void IsExtraHot_Should_Return_False_When_Drink_Was_Not_Set_Extra_Hot()
        {
            // GIVEN
            IHotDrink drink = new Coffee();

            // WHEN
            bool isExtraHot = drink.IsExtraHot();

            // THEN
            Check.That(isExtraHot).IsFalse();
        }

        [Test]
        public void IsExtraHot_Should_Return_True_When_Drink_Was_Set_Extra_Hot()
        {
            // GIVEN
            IHotDrink drink = new Coffee();
            drink.SetExtraHot();

            // WHEN
            bool isExtraHot = drink.IsExtraHot();

            // THEN
            Check.That(isExtraHot).IsTrue();
        }
    }
}
