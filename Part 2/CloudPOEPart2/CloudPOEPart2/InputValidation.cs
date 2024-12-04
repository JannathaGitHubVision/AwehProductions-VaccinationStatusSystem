using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Buffers.Text;
using System.Linq;
using QueueClient = Azure.Storage.Queues.QueueClient;
namespace CloudPOEPart2
{
    public class InputValidation
    {
        /// <summary>
        /// using this class for validation here
        /// </summary>
        ValidationChecker ValidationChecker = new ValidationChecker();

        /// <summary>
        /// connection string for queue
        /// </summary>
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=st10053561;AccountKey=xyMJFImtRxiGcO3QshXd3s7mtt4AuSvqqAdqBZ2J6Uah0BQUR7zx4gVZ+VNr+vhLOQbKiwNn0lMX+ASt+DXjQw==;EndpointSuffix=core.windows.net";
        public void GetInputValues()
        {
            //it looks until the program shuts down
            while (true)
            {
                Console.WriteLine("**********************************************************************************************************");
                Console.WriteLine("ID/Passport Number: VaccinationCenter : VaccineSerialNumber or VaccineBarcode : VaccinationDate");
                Console.WriteLine();

                //Iam storing those values in Input
                string input = Console.ReadLine();

                // Remove spaces from the start and end of the input
                input = input.Trim();

                //To remove space in between colons characters
                 input = input.Replace(" ", "");

                ///It make sure for user to enter colon as manadatory
                if (!input.Contains(':'))
                {
                    Console.WriteLine("Please don't forget to include the ':' ");
                    Console.WriteLine();
                    continue;
                }
                string[] values = input.Split(':');

                //Checking if values are empty
                if (values.Length < 4)
                {
                    Console.WriteLine("Please fill all the values");
                    Console.WriteLine();
                    continue;
                }
                //Iam making sure to enter only four values only
                else if (values.Length > 4)
                {
                    Console.WriteLine("Please fill only 4 values only");
                    continue;
                }
                //based on the length of a character does the following, if 8 then passport else ID
                string idOrPassportNumber;
                if (values[0].Length <=8)
                {
                    idOrPassportNumber = ValidationChecker.IsValidPassport(values[0].Trim());
                }
                else 
                {
                    idOrPassportNumber = ValidationChecker.IsValidID(values[0].Trim());
                }

                //Storing vaccination center
                string vaccinationCenter = ValidationChecker.ValidateCentre(values[1].Trim());

                //It does same process like passport or ID
                string vaccineSerialNumberOrBarcode;

                //Based on the length of a character does the following, if 10 then serial number else barcode
                if (values[2].Length <=10)
                {
                    vaccineSerialNumberOrBarcode = ValidationChecker.ValidateSerialNumber(values[2].Trim());
                }
                else 
                {
                    vaccineSerialNumberOrBarcode = ValidationChecker.ValidateBarCode(values[2].Trim());
                }

                //storing the Vaccination date
                string vaccinationDate = ValidationChecker.DateHandling(values[3].Trim());


                //making sure the values mustn't be null
                if (idOrPassportNumber == null || vaccinationCenter == null || vaccineSerialNumberOrBarcode == null || vaccinationDate == null)
                {
                    continue;
                }

                Console.WriteLine();

                string message;
                ///based on the values they provide it prints accordingly 
                if (values[2].Length == 10)
                {
                    // Store in format: Passport:VaccinationCenter:VaccinationDate:SerialNumber
                    Console.WriteLine("Successfully Stored");
                    Console.WriteLine();
                    message = $"{idOrPassportNumber}:{vaccinationCenter}:{vaccineSerialNumberOrBarcode}:{vaccinationDate}".ToString();
                    Console.WriteLine(message);
                }
                else
                {
                    // Store in format: Barcode:VaccinationDate:VaccinationCenter:ID
                    Console.WriteLine("Successfully Stored");
                    Console.WriteLine();
                    Console.WriteLine($"{vaccineSerialNumberOrBarcode} : {vaccinationDate} : {vaccinationCenter} : {idOrPassportNumber}");
                    message = $"{idOrPassportNumber}:{vaccinationCenter}:{vaccineSerialNumberOrBarcode}:{vaccinationDate}".ToString();
                }
                Console.WriteLine();
               
                AddMessageToQueue(message);
                GetInputValues();
                break;
            }
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
