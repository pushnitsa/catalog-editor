using CatalogEditor.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddContextExtension
    {
        public static IServiceCollection AddContext(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                    .AddTransient(
                        s => new DbContextOptionsBuilder()
                            .UseInMemoryDatabase("CatalogDb")
                            .Options
                    )
                    .AddTransient<IContextFactory, ContextFactory>();
        }
    }
}