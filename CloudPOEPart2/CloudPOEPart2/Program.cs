using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPOEPart2
{
    public class Program
    {
        // This is the entry point of your application.
        public static void Main(string[] args)
        {
            // Display a welcome message to the user and explain the required input format.
            Console.WriteLine("Welcome to our Vaccination Center! \n" +
"We need some information to proceed. You can provide this information in one of two formats:\n");

            // Create an instance of the InputAnotherValidation class.
            InputAnotherValidation inputValues = new InputAnotherValidation();

            // Call the GetInputValues method of the InputAnotherValidation instance to get the user's input.
            inputValues.GetInputValues();

        }
    }
}
