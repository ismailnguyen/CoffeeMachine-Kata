namespace CoffeeMachine
{
    public class ChocolateMaker : DrinkMaker
    {
        public override string Make()
        {
            var chocolate = Drink.Chocolate;

            if (InsertedMoneyAmount < chocolate.Price)
            {
                return string.Format("M:{0:0.00}", GetMissingMoneyAmount(chocolate.Price));
            }

            return chocolate.Make();
        }

        public override string MakeWithSugar(int sugarQuantity = 1)
        {
            var chocolate = Drink.Chocolate;

            if (InsertedMoneyAmount < chocolate.Price)
            {
                return string.Format("M:{0:0.00}", GetMissingMoneyAmount(chocolate.Price));
            }

            return chocolate.MakeWithSugar(sugarQuantity);
        }
    }
}