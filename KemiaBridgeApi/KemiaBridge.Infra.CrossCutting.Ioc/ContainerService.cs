﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using KemiaBridge.Infra.CrossCutting.Dl;
using KemiaBridge.Service.Mappers;
using KemiaBridge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using KemiaBridge.Service.Helpers;
using System.Text;
using Microsoft.Extensions.Logging;

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
