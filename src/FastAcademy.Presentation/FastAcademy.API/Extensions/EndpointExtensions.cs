using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FastAcademy.API.Extensions;

public interface ICoreEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}

public static class EndpointExtensions
{
    public static void AddCoreEndpoints(this IServiceCollection services)
    {
        var serviceDescriptors = typeof(Program).Assembly.DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false } &&
                           type.IsAssignableTo(typeof(ICoreEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(ICoreEndpoint), type))
            .ToList();

        services.TryAddEnumerable(serviceDescriptors);
    }
    
    public static void MapCoreEndpoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<ICoreEndpoint>>();
        
        IEndpointRouteBuilder builder = routeGroupBuilder is null 
            ? app 
            : routeGroupBuilder;

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }
    }
}