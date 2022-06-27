using Event.Infrastructure.AppSettings;
using Event.Infrastructure.Extensions;

namespace Event.API.Config
{
    /// <summary>
    /// Database related configurations
    /// </summary>
    public static class DatabaseConfig
    {
        /// <summary>
        /// Setup Cosmos DB
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void SetupCosmosDb(this IServiceCollection services, IConfiguration configuration)
        {
            // Bind database-related bindings
            CosmosDbSettings cosmosDbConfig = configuration.GetSection("ConnectionString:CosmosDB").Get<CosmosDbSettings>();
            // register CosmosDB client and data repositories
            services.AddCosmosDb(cosmosDbConfig.EndpointUrl,
                                 cosmosDbConfig.PrimaryKey,
                                 cosmosDbConfig.DatabaseName,
                                 cosmosDbConfig.Containers);

        }

    }
}
