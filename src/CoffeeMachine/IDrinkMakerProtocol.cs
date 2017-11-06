namespace CoffeeMachine
{
    public interface IDrinkMakerProtocol
    {
        string BuildMessage();
        void SetDrinkCode(string drinkCode);
    }
}