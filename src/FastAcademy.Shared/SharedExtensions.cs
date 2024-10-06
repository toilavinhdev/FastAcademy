using Microsoft.Extensions.DependencyInjection;

namespace FastAcademy.Shared;

public static class SharedExtensions
{
    public static void AddSharedServices(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddSingleton(appSettings);
    }
}