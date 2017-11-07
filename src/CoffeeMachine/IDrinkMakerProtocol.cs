namespace CoffeeMachine
{
    public interface IDrinkMakerProtocol
    {
        string BuildCommand();
        void SetDrinkCode(string drinkCode);
        void SetSugarQuantity(int v);
        string BuildMessage(string message);
    }
}