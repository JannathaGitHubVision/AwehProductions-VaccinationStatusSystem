using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Container = Microsoft.Azure.Cosmos.Container;


namespace CloudAzurePOE
{
    public class AzureCosmos
    {
        // Azure Cosmos DB configuration parameters
        private static string EndPointUri = "https://tempcosmos.documents.azure.com:443/";
        
        // Azure Cosmos DB client and container objects
        private CosmosClient cosmosClient;
        private Database database;
        private Container container;

        // Database and container identifiers
        private string databaseId = "ToDoList";
        private string containerId = "VaccinationInfo";

        // Constructor initializes the Azure Cosmos client, database, and container
        public AzureCosmos()
        {
            // Create an instance of the CosmosClient using the provided endpoint URI and primary key
            this.cosmosClient = new CosmosClient(EndPointUri, PrimaryKey);
            // Get a reference to the specified database using the databaseId
            this.database = this.cosmosClient.GetDatabase(databaseId);
            // Get a reference to the specified container within the database using the containerId
            this.container = this.database.GetContainer(containerId);

        }

        // Method to add an item to the VaccinationInfo container in Azure Cosmos DB
        public async Task AddItemToVaccinatioContainer(string passport, string ID, string vaccinationCentre, string vaccinationDate, string SerialNumber, string BarCode)
        {
            // Generate a unique identifier for the new item
            string uniqueId = "VAC" + Guid.NewGuid().ToString();

            // Create a dynamic object representing the item with specified properties
            dynamic item = new
            {
                id = uniqueId,
                VaccineID = ID,
                Passport = passport,
                VaccinationCentre = vaccinationCentre,
                VaccinationDate = vaccinationDate,
                VaccinationSerialNumber = SerialNumber,
                VaccinationBarCode = BarCode
            };

            // Add the item to the VaccinationInfo container asynchronously
            var itemResponse = await this.container.CreateItemAsync(item);

            // Log the successful addition of the item to the console
            Console.WriteLine($"Item added with id {itemResponse.Resource.id}");
        }


    }
}
