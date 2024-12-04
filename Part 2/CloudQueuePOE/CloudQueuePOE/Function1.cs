using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace CloudQueuePOE
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([QueueTrigger("cloudanotherqueue", Connection = "connectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            //Here Iam splitting the values to get 
            string[] parts = myQueueItem.Split(":");

            //Iam getting values from queue trigger and storing in a object
            VaccinationStatus vaccination = new VaccinationStatus
            {
                Passport = parts[0].Length == 8 ? parts[0] : null,
                Id = parts[0].Length == 13 ? parts[0] : null,
                VaccinationCentre = parts[1],
                VaccinationSerialNumber = parts[2].Length == 10 ? parts[2] : null,
                VaccinationBarcode1 = parts[2].Length == 13 ? parts[2] : null,
                Vaccinationdate = parts[3]
            };


            //Iam sending those values to Azure SQL database
            DBController dBController = new DBController();
            dBController.Addvalues(vaccination);
        }
    }
}
