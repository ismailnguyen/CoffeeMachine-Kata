using System;

namespace CoffeeMachine
{
    public abstract class HotDrink : IHotDrink
    {
        private string code;
        private int sugarQuantity = 0;
        private double price;
        bool isExtraHot;

        protected HotDrink(string code, double price)
        {
            this.code = code;
            this.price = price;
        }

        public HotDrink AddSugar()
        {
            if (sugarQuantity >= 2)
            {
                return this;
            }

            sugarQuantity++;

            return this;
        }

        public string GetCode()
        {
            return code;
        }

        public double GetPrice()
        {
            return price;
        }

        public int GetSugarQuantity()
        {
            return sugarQuantity;
        }

        public bool IsExtraHot()
        {
            return isExtraHot;
        }

        public void SetExtraHot()
        {
            isExtraHot = true;
        }
    }
}
