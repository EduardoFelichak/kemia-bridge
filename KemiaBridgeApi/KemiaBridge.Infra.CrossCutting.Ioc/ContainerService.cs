using KemiaBridge.Infra.CrossCutting.Dl;
using KemiaBridge.Infra.Data.Context;
using KemiaBridge.Service.Helpers;
using KemiaBridge.Service.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata      = false;
                x.SaveToken                 = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey         = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key.Secret())),
                    ValidateIssuer           = false,
                    ValidateAudience         = false,
                };
            });
        }
    }
}
