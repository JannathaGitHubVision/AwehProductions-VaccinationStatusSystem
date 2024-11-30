using DocumentFormat.OpenXml.Math;
using System;
namespace CloudAzurePOE
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run(
            [QueueTrigger("cloudanotherqueue", Connection = "Connect")] string myQueueItem,
            ILogger log, ExecutionContext executionContext)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            AzureCosmos azureCosmos = new AzureCosmos();

            //Here Iam splitting the values to get 
            string[] parts = myQueueItem.Split(":");

            // Create a new VaccinationStatus object
            VaccinationStatus vaccination = new VaccinationStatus();

            // Check the position of the ID or Passport number to determine the format
            if (parts[0].Length == 8 || parts[0].Length == 13) // ID or Passport number is at the beginning
            {
                vaccination.Id = parts[0].Length == 13 ? parts[0] : null;
                vaccination.Passport = parts[0].Length == 8 ? parts[0] : null;
                vaccination.VaccinationCentre = parts[1];
                vaccination.Vaccinationdate = parts[2];
                vaccination.VaccinationSerialNumber = parts[3].Length == 10 ? parts[3] : null;
                vaccination.VaccinationBarcode1 = parts[3].Length == 13 ? parts[3] : null;
            }
            else // ID or Passport number is at the end
            {
                vaccination.VaccinationSerialNumber = parts[0].Length == 10 ? parts[0] : null;
                vaccination.VaccinationBarcode1 = parts[0].Length == 13 ? parts[0] : null;
                vaccination.Vaccinationdate = parts[1];
                vaccination.VaccinationCentre = parts[2];
                vaccination.Id = parts[3].Length == 13 ? parts[3] : null;
                vaccination.Passport = parts[3].Length == 8 ? parts[3] : null;
            }

            ///Sending values to azure cosmos DB
            try
            {
                // Attempt to add an item to the Azure Cosmos container using the provided parameters.
                azureCosmos.AddItemToVaccinatioContainer(vaccination.Passport, vaccination.Id, vaccination.VaccinationCentre, vaccination.Vaccinationdate, vaccination.VaccinationSerialNumber, vaccination.VaccinationBarcode1).Wait();

            }
            catch (AggregateException ax)
            {
                // Catch any exceptions that may occur during the asynchronous operation.
                ax.Handle((x) =>
                {
                    // Check if the caught exception is of type CosmosException (specific to Azure Cosmos DB).
                    if (x is CosmosException)
                    {
                        // Log the details of the CosmosException to the console.
                        Console.WriteLine($"Caught CosmosException: {x.Message}");
                        return true; // Indicate that the exception has been handled.
                    }

                    // If the exception is not a CosmosException, indicate that it has not been handled.
                    return false;
                });
            }



            //Iam sending those values to Azure SQL database
            //DBController dBController = new DBController();
            //dBController.Addvalues(vaccination);

        }

    }


}

