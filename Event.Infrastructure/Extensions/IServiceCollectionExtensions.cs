using Event.Infrastructure.AppSettings;
using Event.Infrastructure.CosmosDB;
using Event.Infrastructure.CosmosDB.Interfaces;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;

namespace Event.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Register a singleton instance of Cosmos Db Container Factory, which is a wrapper for the CosmosClient.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="endpointUrl"></param>
        /// <param name="primaryKey"></param>
        /// <param name="databaseName"></param>
        /// <param name="containers"></param>
        /// <returns></returns>
        public static IServiceCollection AddCosmosDb(this IServiceCollection services,
                                                     string endpointUrl,
                                                     string primaryKey,
                                                     string databaseName,
                                                     List<ContainerInfo> containers)
        {
            CosmosClient client = new(endpointUrl, primaryKey);
            CosmosDbContainerFactory cosmosDbClientFactory = new(client, databaseName, containers);

            // Microsoft recommends a singleton client instance to be used throughout the application
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.cosmos.cosmosclient?view=azure-dotnet#definition
            // "CosmosClient is thread-safe. Its recommended to maintain a single instance of CosmosClient per lifetime of the application which enables efficient connection management and performance"
            services.AddSingleton<ICosmosDbContainerFactory>(cosmosDbClientFactory);

            return services;
        }
    }
}
