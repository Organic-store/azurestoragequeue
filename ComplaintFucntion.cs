using System;
using System.Collections.Generic;
using azurestoragequeue.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace azurestoragequeue
{
    public static class ComplaintFucntion
    {
        [FunctionName("ComplaintFucntion")]
        public static void Run([QueueTrigger("queue-store-55", Connection = "ConnectionStrings:AZURE_STORAGE_CONNECTION_STRING")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");


            var data = JsonConvert.DeserializeObject<Messages>(myQueueItem);
            var client = new MongoClient(System.Environment.GetEnvironmentVariable("MONGO_DB_CONNECTION_STRING"));

            var database = client.GetDatabase("organic");
            var collection = database.GetCollection<complaints>("complaints");



            if (data != null)
            {

                var searchResult1 = collection.Find<complaints>(x => x.productname.ToLower().Contains(data.productname.ToLower())).FirstOrDefault();
                if (searchResult1 != null)
                {
                    searchResult1.count += 1;
                    var filter = Builders<complaints>.Filter.Eq("productname", searchResult1.productname);
                    var update = Builders<complaints>.Update.Set("count", searchResult1.count);
                    collection.UpdateOne(filter, update);
                }

            }
        }
    }

}
