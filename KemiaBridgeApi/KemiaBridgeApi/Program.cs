using KemiaBridge.Infra.CrossCutting.Ioc;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography.Xml;

namespace KemiaBridgeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.Local.json", optional: false, reloadOnChange: true);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name   = "Authorization",
                    In     = ParameterLocation.Header,
                    Type   = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id   = "Bearer",
                            },
                            Scheme = "oauth2",
                            Name   = "Bearer",
                            In     = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            ContainerService.RegisterServices(builder.Services, builder.Configuration);

            var app = builder.Build();
        
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.RegisterMiddlewares();

            app.Run();
        }
    }
}