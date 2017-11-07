namespace CoffeeMachine
{
    public interface IHotDrink : IDrink
    {
        int GetSugarQuantity();
        bool IsExtraHot();
        void SetExtraHot();
    }
}
