namespace CoffeeMachine
{
    public interface IDrinkMakerProtocol
    {
        string BuildMessage(string message);
        string BuildCommand(IDrinkOrder drinkOrder);
    }
}