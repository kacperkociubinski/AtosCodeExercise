using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Application.Common.Interfaces;

namespace Persistance
{
    public static class ServiceConfiguration
    {
        public static void ConfigurePersistance(this IServiceCollection services)
        {
            services.AddDbContext<CustomerContext>(options => options.UseInMemoryDatabase("CustomerDatabase"));
            services.AddScoped<ICustomerContext>(provider => provider.GetRequiredService<CustomerContext>());

        }
    }
}
