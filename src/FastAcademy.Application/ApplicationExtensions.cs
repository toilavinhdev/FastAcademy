using System.Reflection;
using FastAcademy.Application.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FastAcademy.Application;

public static class ApplicationExtensions
{
    public static Assembly Assembly => typeof(ApplicationExtensions).Assembly;
    
    public static void AddApplicationServices(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddValidatorsFromAssembly(Assembly);
        
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(Assembly);
            c.AddOpenBehavior(typeof(ValidationBehavior<,>));
            c.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
    }
}