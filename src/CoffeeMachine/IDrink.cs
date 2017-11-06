namespace CoffeeMachine
{
    public interface IDrink
    {
        string GetCode();
        int GetSugarQuantity();
        IDrink AddSugar();
    }
}