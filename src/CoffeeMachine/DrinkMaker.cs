namespace CoffeeMachine
{
    public class DrinkMaker
    {
        private const string COFFEE = "C";
        private const string TEA = "T";
        private const string CHOCOLATE = "H";
        private const string DRINK_WITH_SUGAR_CODE = "{0}:{1}:1";
        private const string DRINK_WITHOUT_SUGAR_CODE = "{0}::";

        private string makeCoffee()
        {
            return string.Format(DRINK_WITHOUT_SUGAR_CODE, COFFEE);
        }

        private string makeCofeeWithSugar(int sugarQuantity)
        {
            return string.Format(DRINK_WITH_SUGAR_CODE, COFFEE, sugarQuantity);
        }

        public string Coffee()
        {
            var drink = new Drink();

            return drink.Make();
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
            return string.Format(DRINK_WITHOUT_SUGAR_CODE, TEA);
        }

        private string makeTeaWithSugar(int sugarQuantity)
        {
            return string.Format(DRINK_WITH_SUGAR_CODE, TEA, sugarQuantity);
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
            return string.Format(DRINK_WITHOUT_SUGAR_CODE, CHOCOLATE);
        }

        private string makeChocolateWithSugar(int sugarQuantity)
        {
            return string.Format(DRINK_WITH_SUGAR_CODE, CHOCOLATE, sugarQuantity);
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