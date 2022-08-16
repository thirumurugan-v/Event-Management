using Event.Domain.Models;
using Event.Domain.Models.Common.Interface;
using Event.Infrastructure.Context;
using Event.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Event.Infrastructure.Extensions
{
    public static class UnitOfWorkExtension
    {
        public static IServiceCollection SetupUnitOfWork([NotNullAttribute] this IServiceCollection serviceCollection)
        {
            //TODO: Find a way to inject the repositories and share the same context without creating a instance.
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>(f =>
            {
                var scopeFactory = f.GetRequiredService<IServiceScopeFactory>();
                var context = f.GetService<EventContext>();
                return new UnitOfWork(
                    context,
                    new EventRepository(context),
                    new CityRepository(context),
                    new CategoryRepository(context)
                );
            });
            return serviceCollection;
        }
    }
}
