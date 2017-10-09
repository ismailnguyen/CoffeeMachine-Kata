namespace CoffeeMachine
{
    public class DrinkMaker
    {
        public double InsertedMoneyAmount { get; private set; }

        public void InsertMoney(double moneyAmount)
        {
            InsertedMoneyAmount += moneyAmount;
        }

        public double GetMissingMoneyAmount(double drinkPrice)
        {
            return drinkPrice - InsertedMoneyAmount;
        }

        public string Coffee()
        {
            var coffee = Drink.Coffee;

            if (InsertedMoneyAmount < coffee.Price)
            {
                return string.Format("M:{0:0.00}", GetMissingMoneyAmount(coffee.Price));
            }

            return coffee.Make();
        }

        public string CoffeeWithSugar(int sugarQuantity = 1)
        {
            var coffee = Drink.Coffee;

            return coffee.MakeWithSugar(sugarQuantity);
        }

        public object Tea()
        {
            var tea = Drink.Tea;

            return tea.Make();
        }

        public object TeaWithSugar(int sugarQuantity = 1)
        {
            var tea = Drink.Tea;

            return tea.MakeWithSugar(sugarQuantity);
        }

        public object Chocolate()
        {
            var chocolate = Drink.Chocolate;

            return chocolate.Make();
        }

        public object ChocolateWithSugar(int sugarQuantity = 1)
        {
            var chocolate = Drink.Chocolate;

            return chocolate.MakeWithSugar(sugarQuantity);
        }

        public object ForwardMessage()
        {
            return "M:message-content";
        }
    }
}