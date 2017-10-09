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

        private string makeCofeeWithSugar(int sugarQuantity)
        {
            return string.Format("{0}:{1}:1", COFFEE, sugarQuantity);
        }

        public string Coffee()
        {
            return makeCoffee();
        }

        public string CoffeeWithSugar()
        {
            return makeCofeeWithSugar(1);
        }

        public string CoffeeWithTwoSugar()
        {
            return makeCofeeWithSugar(2);
        }

        private string makeTea()
        {
            return string.Format("{0}::", TEA);
        }

        private string makeTeaWithSugar(int sugarQuantity)
        {
            return string.Format("{0}:{1}:1", TEA, sugarQuantity);
        }

        public object Tea()
        {
            return makeTea();
        }

        public object TeaWithSugar()
        {
            return makeTeaWithSugar(1);
        }

        public object TeaWithTwoSugar()
        {
            return makeTeaWithSugar(2);
        }

        private string makeChocolate()
        {
            return string.Format("{0}::", CHOCOLATE);
        }

        private string makeChocolateWithSugar(int sugarQuantity)
        {
            return string.Format("{0}:{1}:1", CHOCOLATE, sugarQuantity);
        }

        public object Chocolate()
        {
            return makeChocolate();
        }

        public object ChocolateWithSugar()
        {
            return makeChocolateWithSugar(1);
        }

        public object ChocolateWithTwoSugar()
        {
            return makeChocolateWithSugar(2);
        }
    }
}