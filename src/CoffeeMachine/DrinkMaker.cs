using System;

namespace CoffeeMachine
{
    public class DrinkMaker
    {
        private const string COFFEE = "C";
        private const string TEA = "T";
        private const string CHOCOLATE = "H";

        private string makeCoffee()
        {
            return string.Format("{0}::", COFFEE);
        }

        private string makeCoffee(int sugar)
        {
            return string.Format("{0}:{1}:1", COFFEE, sugar);
        }

        public string Coffee()
        {
            return makeCoffee();
        }

        public string CoffeeWithSugar()
        {
            return makeCoffee(1);
        }

        public string CoffeeWithTwoSugar()
        {
            return makeCoffee(2);
        }

        public object Tea()
        {
            return TEA + "::";
        }

        public object TeaWithSugar()
        {
            return TEA + ":1:1";
        }

        public object TeaWithTwoSugar()
        {
            return TEA + ":2:1";
        }

        public object Chocolate()
        {
            return CHOCOLATE + "::";
        }

        public object ChocolateWithSugar()
        {
            return CHOCOLATE + ":1:1";
        }

        public object ChocolateWithTwoSugar()
        {
            return CHOCOLATE + ":2:1";
        }
    }
}