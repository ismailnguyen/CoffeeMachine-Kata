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

        public object Tea()
        {
            return "T::";
        }

        public object TeaWithSugar()
        {
            return "T:1:1";
        }

        public object TeaWithTwoSugar()
        {
            return "T:2:1";
        }
    }
}