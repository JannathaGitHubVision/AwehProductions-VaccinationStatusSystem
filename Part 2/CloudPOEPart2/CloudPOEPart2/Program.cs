using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPOEPart2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Vaccination Center! \n" +
            "To proceed, please provide the following information:\n" +
            "1. Your ID (numeric, up to 10 digits) or Passport Number (first char letter rest numeric,up to 8 characters) \n" +
            "2. The Vaccination Center you visited (text)\n" +
            "3. Your Vaccine Serial Number (numeric, 10 characters) or Vaccine Barcode (numeric, 13 characters)\n" +
            "4. The date you were vaccinated (format: dd/mm/yyyy)\n\n" +
            "Please note that the information should be provided in the following format:\n");

            InputValidation inputValues = new InputValidation();
            inputValues.GetInputValues();
        }
    }
}
