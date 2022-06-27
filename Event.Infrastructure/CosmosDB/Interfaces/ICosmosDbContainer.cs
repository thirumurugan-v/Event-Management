using Microsoft.Azure.Cosmos;

namespace Event.Infrastructure.CosmosDB.Interfaces
{
    public interface ICosmosDbContainer
    {
        /// <summary>
        ///     Instance of Azure Cosmos DB Container class
        /// </summary>
        Container Container { get; }
    }
}
