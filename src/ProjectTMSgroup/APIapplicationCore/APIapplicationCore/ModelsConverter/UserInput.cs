using APIapplicationCore.Manager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIapplicationCore.ModelsConverter
{
    public class UserInput
    {
        public string CurrencyNameUserInput { get; set; }

        public string DateUserInput { get; set; }

        public void UserInp()
        {
            Console.Write("Enter the dates(YY-MM-DD): ");
            DateUserInput = Console.ReadLine();

            Console.Write("Enter the name of the currency to get the rate (USD/EUR/RUB): ");
            CurrencyNameUserInput = Console.ReadLine();
        }
    }
}
