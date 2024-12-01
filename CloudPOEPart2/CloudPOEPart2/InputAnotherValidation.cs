using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPOEPart2
{
    public class InputAnotherValidation
    {
        /// <summary>
        /// using this class for validation here
        /// </summary>
        ValidationChecker ValidationChecker = new ValidationChecker();

        /// <summary>
        /// connection string for queue
        /// </summary>
        //string connectionString = "DefaultEndpointsProtocol=https;AccountName=st10053561;AccountKey=xyMJFImtRxiGcO3QshXd3s7mtt4AuSvqqAdqBZ2J6Uah0BQUR7zx4gVZ+VNr+vhLOQbKiwNn0lMX+ASt+DXjQw==;EndpointSuffix=core.windows.net";
        // This method initiates the process of getting input values based on the user's choice.
        public void GetInputValues()
        {
            // Get the user's choice by calling the OpeningInfo method.
            int choice = OpeningInfo();

            // Display a separator and new line for clarity.
            Console.WriteLine();

            // Display a separator and new line for each iteration.
            Console.WriteLine("**********************************************************************************************************");
            Console.WriteLine();

            // Check the user's choice and execute the corresponding method.
            if (choice.Equals(1))
            {
                // Call the method to get and validate input values based on choice one format.
                ValidChoiceone();
            }
            else if (choice.Equals(2))
            {
                // Call the method to get and validate input values based on choice two format.
                ValidChoiceTwo();


            }
        }


        /// <summary>
        /// This method prompts the user to provide vaccination information in a format one and validates the input.
        /// </summary>

        public void ValidChoiceone()
        {
            while (true)
            {
                // Display instructions to the user about the required input format.
                Console.WriteLine("Please provide your information in the following format : \n");
                Console.WriteLine("Id/Passport No:VaccinationCenter:VaccinationDate:VaccineSerialNumber");

                Console.WriteLine();

                // Read user input.
                string input = Console.ReadLine();

                // Trim leading and trailing spaces and remove any spaces within the input.
                input = input.Trim();
                input = input.Replace(" ", "");

                // Check if the input contains the required ':' separator.
                if (!input.Contains(':'))
                {
                    // Display an error message if ':' is missing and return from the method.
                    Console.WriteLine("Please don't forget to include the ':' ");
                    Console.WriteLine();
                    continue;
                }

                // Split the input into an array of values using ':' as the separator.
                string[] values = input.Split(':');

                // Check if the number of values is less than 4.
                if (values.Length < 4)
                {
                    // Display an error message if not all values are provided and continue from the method.
                    Console.WriteLine("Please fill all the values");
                    Console.WriteLine();
                    continue;
                }
                // Check if the number of values is more than 4.
                else if (values.Length > 4)
                {
                    // Display an error message if more than 4 values are provided and continue from the method.
                    Console.WriteLine("Please fill only 4 values");
                    continue;
                }

                // Determine whether to validate the ID or passport number based on its length.
                string idOrPassportNumber;
                if (values[0].Length <= 8)
                {
                    idOrPassportNumber = ValidationChecker.IsValidPassport(values[0].Trim());
                }
                else
                {
                    idOrPassportNumber = ValidationChecker.IsValidID(values[0].Trim());
                }

                // Validate the vaccination center value.
                string vaccinationCenter = ValidationChecker.ValidateCentre(values[1].Trim());

                // Validate the vaccination date value.
                string vaccinationDate = ValidationChecker.DateHandling(values[2].Trim());

                // Validate the vaccine serial number or barcode value.
                string vaccineSerialNumberOrBarcode = ValidationChecker.ValidateSerialNumber(values[3].Trim());

                // Ensure that none of the validated values are null.
                if (idOrPassportNumber == null || vaccinationCenter == null || vaccineSerialNumberOrBarcode == null || vaccinationDate == null)
                {
                    // If any value is null, continue from the method.
                    continue;
                }

                // Construct a message in the specified format.
                string message;
                Console.WriteLine();
                // Display a success message.
                Console.WriteLine("Successfully Stored");
                Console.WriteLine();

                // Concatenate the validated values into a message string.
                message = $"{idOrPassportNumber}:{vaccinationCenter}:{vaccinationDate}:{vaccineSerialNumberOrBarcode}".ToString();

                // Display the message.
                Console.WriteLine(message);
                Console.WriteLine("*****************************************************************************************************************");

                Console.WriteLine();
                // Add the message to a queue 
                AddMessageToQueue(message);
                GetInputValues();
                break;
            }
            
        }

        /// <summary>
        /// This method prompts the user to provide vaccination information in a format two and validates the input. 
        /// </summary>
        public void ValidChoiceTwo()
        {
            while (true)
            {
                // Display instructions to the user about the required input format.
                Console.WriteLine("Please provide your information in the following format : \n");
                Console.WriteLine("VaccineBarcode:VaccinationDate:VaccinationCenter:Id/Passport No");

                Console.WriteLine();

                // Read user input.
                string input = Console.ReadLine();

                // Trim leading and trailing spaces and remove any spaces within the input.
                input = input.Trim();
                input = input.Replace(" ", "");

                // Check if the input contains the required ':' separator.
                if (!input.Contains(':'))
                {
                    // Display an error message if ':' is missing and return from the method.
                    Console.WriteLine("Please don't forget to include the ':' ");
                    Console.WriteLine();
                    continue;
                }

                // Split the input into an array of values using ':' as the separator.
                string[] values = input.Split(':');

                // Check if the number of values is less than 4.
                if (values.Length < 4)
                {
                    // Display an error message if not all values are provided and continue from the method.
                    Console.WriteLine("Please fill all the values");
                    Console.WriteLine();
                    continue;
                }
                // Check if the number of values is more than 4.
                else if (values.Length > 4)
                {
                    // Display an error message if more than 4 values are provided and continue from the method.
                    Console.WriteLine("Please fill only 4 values");
                    continue;
                }

                // Validate the vaccine serial number or barcode value.
                string vaccineSerialNumberOrBarcode = ValidationChecker.ValidateBarCode(values[0].Trim());

                // Validate the vaccination date value.
                string vaccinationDate = ValidationChecker.DateHandling(values[1].Trim());

                // Validate the vaccination center value.
                string vaccinationCenter = ValidationChecker.ValidateCentre(values[2].Trim());

                // Determine whether to validate the ID or passport number based on its length.
                string idOrPassportNumber;
                if (values[3].Length <= 8)
                {
                    idOrPassportNumber = ValidationChecker.IsValidPassport(values[3].Trim());
                }
                else
                {
                    idOrPassportNumber = ValidationChecker.IsValidID(values[3].Trim());
                }

                // Ensure that none of the validated values are null.
                if (idOrPassportNumber == null || vaccinationCenter == null || vaccineSerialNumberOrBarcode == null || vaccinationDate == null)
                {
                    // If any value is null, continue from the method.
                    continue;
                }

                // Construct a message in the specified format.
                string message;
                Console.WriteLine();
                // Display a success message.
                Console.WriteLine("Successfully Stored");
                Console.WriteLine();
                // Concatenate the validated values into a message string.
                message = $"{vaccineSerialNumberOrBarcode}:{vaccinationDate}:{vaccinationCenter}:{idOrPassportNumber}".ToString();

                Console.WriteLine(message);
                Console.WriteLine("*****************************************************************************************************************");
                Console.WriteLine();
                // Add the message to a queue 
                AddMessageToQueue(message);
                GetInputValues();
                break;
            };
             

        }


        /// <summary>
        /// This is a opening information and instructions
        /// </summary>
        /// <returns></returns>
        private static int OpeningInfo()
        {
            // Displaying the options for the user to choose from along with the required input format.
            Console.WriteLine("Option 1: ID or South African Passport Number, Vaccination Center, Vaccination Date, Vaccine Serial Number\n" +
                "Format: Id:VaccinationCenter:VaccinationDate:VaccineSerialNumber\n\n" +
                "Option 2: Vaccine Barcode, Vaccination Date, Vaccination Center, ID or South African Passport Number\n" +
                "Format: VaccineBarcode:VaccinationDate:VaccinationCenter:Id\n\n" +
                "Please choose the option that is most convenient for you. Thank you for your cooperation!");

            // Declare a variable to store the user's choice.
            int choice;

            // Use a while loop to repeatedly prompt the user until a valid choice (1 or 2) is entered.
            while (true)
            {
                // Read the user's input and attempt to parse it as an integer.
                // Also, check if the entered choice is either 1 or 2.
                if (int.TryParse(Console.ReadLine(), out choice) && (choice == 1 || choice == 2))
                {
                    // Break out of the loop if a valid choice is entered.
                    break;
                }
                else
                {
                    // Display an error message for invalid input and prompt the user to enter a valid choice.
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Please enter either 1 or 2.");
                }
            }

            // Return the user's valid choice.
            return choice;
        }

        /// <summary>
        /// Adding the messages to a queue
        /// </summary>
        /// <param name="message"></param>

        public void AddMessageToQueue(string mesage)
        {
            CloudStorageAccount cloudStorage = CloudStorageAccount.Parse(connectionString);
            CloudQueueClient client = cloudStorage.CreateCloudQueueClient();
            CloudQueue queue = client.GetQueueReference("cloudanotherqueue");
            CloudQueueMessage message = new CloudQueueMessage(mesage);
            queue.AddMessageAsync(message).Wait();
        }

    }
}
