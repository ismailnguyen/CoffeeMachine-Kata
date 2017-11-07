namespace CoffeeMachine
{
    public interface IHotDrink : IDrink
    {
        HotDrink AddSugar();
        int GetSugarQuantity();
        bool IsExtraHot();
        void SetExtraHot();
    }
}
