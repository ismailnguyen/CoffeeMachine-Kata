namespace CoffeeMachine
{
    public abstract class ColdDrink : Drink, IColdDrink
    {
        public ColdDrink(string code, double price) : base(code, price)
        {
        }
    }
}