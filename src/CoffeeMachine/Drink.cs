using System.Text;

namespace CoffeeMachine
{
    public class Drink
    {
        private string drinkCode;
        private bool isExtraHot;

        private int sugars;
        public double Price { get; private set; }

        public Drink(string drinkCode, double price)
        {
            this.drinkCode = drinkCode;
            Price = price;
        }

        public void AddSugar()
        {
            if (sugars == 2)
            {
                return;
            }

            sugars++;
        }

        public void SetExtraHot()
        {
            isExtraHot = true;
        }

        public string BuildCommand()
        {
            var command = new StringBuilder(drinkCode);

            if (isExtraHot)
            {
                command.Append("h");
            }

            if (sugars > 0)
            {
                command.AppendFormat(":{0}:1", sugars);
            }
            else
            {
                command.Append("::");
            }

            return command.ToString();
        }
    }
}