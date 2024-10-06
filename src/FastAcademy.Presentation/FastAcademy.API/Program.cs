using FastAcademy.API.Extensions;
using FastAcademy.Application;
using FastAcademy.Packages;
using FastAcademy.Persistence;
using FastAcademy.Shared;

var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureLogging()
    .GetEnvironments(out var appSettings);

var services = builder.Services;
services.AddSharedServices(appSettings);
services.AddCoreServices(appSettings);
services.AddPersistenceServices(appSettings);
services.AddPackagesServices(appSettings);
services.AddApplicationServices(appSettings);

var app = builder.Build();
app.UseCoreMiddlewares(appSettings);
app.MapGet("/ping", () => "Pong");
app.Run();