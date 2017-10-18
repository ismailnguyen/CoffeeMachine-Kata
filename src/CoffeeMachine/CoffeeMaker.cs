namespace CoffeeMachine
{
    public class CoffeeMaker : DrinkMaker
    {
        public override string Make()
        {
            var coffee = Drink.Coffee;

            if (InsertedMoneyAmount < coffee.Price)
            {
                return string.Format("M:{0:0.00}", GetMissingMoneyAmount(coffee.Price));
            }

            return coffee.Make();
        }

        public override string MakeWithSugar(int sugarQuantity = 1)
        {
            var coffee = Drink.Coffee;

            if (InsertedMoneyAmount < coffee.Price)
            {
                return string.Format("M:{0:0.00}", GetMissingMoneyAmount(coffee.Price));
            }

            return coffee.MakeWithSugar(sugarQuantity);
        }
    }
}