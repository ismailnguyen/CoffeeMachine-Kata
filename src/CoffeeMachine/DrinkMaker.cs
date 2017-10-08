using System;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public DrinkMaker()
        {
        }

        public string Coffee()
        {
            return "C::";
        }

        public string CoffeeWithSugar()
        {
            return "C:1:1";
        }

        public string CoffeeWithTwoSugar()
        {
            return "C:2:1";
        }
    }
}