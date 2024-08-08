using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using KemiaBridge.Infra.CrossCutting.Dl;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace KemiaBridge.Infra.CrossCutting.Ioc
{
    public class ContainerService
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConnectionContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")!));

            services.AddScopedConfig();
            services.RegisterMappings();
        }
    }
}
