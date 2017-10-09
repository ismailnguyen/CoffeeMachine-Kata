namespace CoffeeMachine
{
    public class DrinkMaker
    {
        private const string TEA = "T";
        private const string CHOCOLATE = "H";
        private const string DRINK_WITH_SUGAR_CODE = "{0}:{1}:1";
        private const string DRINK_WITHOUT_SUGAR_CODE = "{0}::";

        public string Coffee()
        {
            var coffee = Drink.Coffee;

            return coffee.Make();
        }

        public string CoffeeWithSugar()
        {
            var coffee = Drink.Coffee;

            return coffee.MakeWithSugar(1);
        }

        public string CoffeeWithTwoSugar()
        {
            var coffee = Drink.Coffee;

            return coffee.MakeWithSugar(2);
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