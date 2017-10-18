namespace CoffeeMachine
{
    public class TeaMaker : DrinkMaker
    {
        public override string Make()
        {
            var tea = Drink.Tea;

            if (InsertedMoneyAmount < tea.Price)
            {
                return string.Format("M:{0:0.00}", GetMissingMoneyAmount(tea.Price));
            }

            return tea.Make();
        }

        public override string MakeWithSugar(int sugarQuantity = 1)
        {
            var tea = Drink.Tea;

            if (InsertedMoneyAmount < tea.Price)
            {
                return string.Format("M:{0:0.00}", GetMissingMoneyAmount(tea.Price));
            }

            return tea.MakeWithSugar(sugarQuantity);
        }
    }
}