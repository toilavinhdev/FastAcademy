using FastAcademy.Application;
using FastAcademy.Packages;
using FastAcademy.Persistence;
using FastAcademy.Shared;
using FastAcademy.Shared.Extensions;

namespace FastAcademy.API.Extensions;

public static class FastAcademyExtensions
{
    public static void AddCoreServices(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddHttpContextAccessor();
        services.AddCoreCors(appSettings.Metadata);
        services.AddCoreAuth(appSettings.JwtOptions);
        services.AddCoreSwagger(appSettings.Metadata);
        services.AddCoreEndpoints();
        services.AddCoreMapper(
        [ApplicationExtensions.Assembly,
            PersistenceExtensions.Assembly,
            PackagesExtensions.Assembly]);
    }

    public static void UseCoreMiddlewares(this WebApplication app, AppSettings appSettings)
    {
        app.UseCoreExceptionHandler();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCoreCors(appSettings.Metadata);
        app.UseCoreAuth();
        app.UseCoreSwagger(appSettings.Metadata);
        app.MapCoreEndpoints();
    }
}