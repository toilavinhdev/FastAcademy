using FastAcademy.Shared;
using FastAcademy.Shared.Exceptions;
using FluentValidation;
using Serilog;
using Serilog.Events;

namespace FastAcademy.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder GetEnvironments(this WebApplicationBuilder builder, out AppSettings appSettings)
    {
        const string folderName = "AppSettings";
        appSettings = new AppSettings();
        var environment = builder.Environment;
        var json = $"appsettings.{environment.EnvironmentName}.json";
        var path = Path.Combine(folderName, json);

        new ConfigurationBuilder()
            .SetBasePath(environment.ContentRootPath)
            .AddJsonFile(path)
            .AddEnvironmentVariables()
            .Build()
            .Bind(appSettings);
        
        return builder;
    }
    
    public static WebApplicationBuilder ConfigureLogging(this WebApplicationBuilder builder)
    {
        const string logPath = "Logs/logs.txt";
        
        builder.Host.UseSerilog((_ , configuration) =>
        {
            configuration
                .Filter.ByExcluding(@event => @event.Exception is DomainException or ValidationException)
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    path: logPath,
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Error);
        });
        
        builder.Logging
            .ClearProviders()
            .AddSerilog();
        
        return builder;
    }
}