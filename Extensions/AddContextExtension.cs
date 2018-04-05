using CatalogEditor.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddContextExtension
    {
        public static IServiceCollection AddContext(this IServiceCollection serviceCollection, string dbName)
        {
            return serviceCollection
                    .AddTransient(
                        s => new DbContextOptionsBuilder()
                            .UseInMemoryDatabase(dbName)
                            .Options
                    )
                    .AddTransient<IContextFactory, ContextFactory>();
        }
    }
}