using System;

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

        public object Tea()
        {
            var tea = Drink.Tea;

            return tea.Make();
        }

        public object TeaWithSugar()
        {
            var tea = Drink.Tea;

            return tea.MakeWithSugar(1);
        }

        public object TeaWithTwoSugar()
        {
            var tea = Drink.Tea;

            return tea.MakeWithSugar(2);
        }

        public object Chocolate()
        {
            var chocolate = Drink.Chocolate;

            return chocolate.Make();
        }

        public object ChocolateWithSugar()
        {
            var chocolate = Drink.Chocolate;

            return chocolate.MakeWithSugar(1);
        }

        public object ChocolateWithTwoSugar()
        {
            var chocolate = Drink.Chocolate;

            return chocolate.MakeWithSugar(2);
        }

        public object ForwardMessage()
        {
            return "M:message-content";
        }
    }
}