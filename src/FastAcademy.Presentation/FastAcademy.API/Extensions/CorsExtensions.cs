using FastAcademy.Shared;

namespace FastAcademy.API.Extensions;

public static class CorsExtensions
{
    public static void AddCoreCors(this IServiceCollection services, Metadata metadata)
    {
        services.AddCors(o =>
        {
            o.AddPolicy(metadata.Name, b =>
            {
                b.AllowCredentials()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(_ => true);
            });
        });
    }

    public static void UseCoreCors(this WebApplication app, Metadata metadata)
    {
        app.UseCors(metadata.Name);
    }
}