using CoffeeMachine;
using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
