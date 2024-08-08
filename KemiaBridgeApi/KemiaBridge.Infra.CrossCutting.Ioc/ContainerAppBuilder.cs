using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace KemiaBridge.Infra.CrossCutting.Ioc
{
    public static class ContainerAppBuilder
    {
        private static IApplicationBuilder UseExceptions(this IApplicationBuilder builder)
        {
            builder.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                if (exceptionHandlerPathFeature != null)
                {
                    var exception = exceptionHandlerPathFeature.Error;
                    context.Response.ContentType = "application/json";
                    var response = new
                    {
                        Success = false,
                        Messages = new List<string> { exception.Message }
                    };
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                }
            }));
            return builder;
        }

        public static IApplicationBuilder RegisterMiddlewares(this IApplicationBuilder builder)
        {
            builder.UseExceptions();
            builder.UseAuthentication();
            builder.UseAuthorization();
            return builder;
        }
    }
}
