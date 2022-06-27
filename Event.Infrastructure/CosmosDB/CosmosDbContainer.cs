using Event.Infrastructure.CosmosDB.Interfaces;
using Microsoft.Azure.Cosmos;

namespace Event.Infrastructure.CosmosDB
{
    public class CosmosDbContainer : ICosmosDbContainer
    {
        public Container Container { get; }

        public CosmosDbContainer(CosmosClient cosmosClient,
                                 string databaseName,
                                 string containerName)
        {
            this.Container = cosmosClient.GetContainer(databaseName, containerName);
        }
    }
}
