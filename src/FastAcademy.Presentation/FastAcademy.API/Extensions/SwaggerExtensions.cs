using FastAcademy.Shared;
using Microsoft.OpenApi.Models;

namespace FastAcademy.API.Extensions;

public static class SwaggerExtensions
{
    private const string DocumentName = "swagger-v1";

    public static void AddCoreSwagger(this IServiceCollection services, Metadata metadata)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(
            o =>
            {
                o.SwaggerDoc(DocumentName, new OpenApiInfo
                {
                    Title = metadata.Name,
                    Version = "v1",
                    Description = $"Summary of APIs of {metadata.Name}"
                });
                
                o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. " +
                                  "\r\n\r\n Enter 'Bearer' [space] and then your token in the text input below." +
                                  "\r\n\r\nExample: \"Bearer accessToken\"",
                });
                
                o.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        }, []
                    }
                });
            });
    }
    
    public static void UseCoreSwagger(this WebApplication app, Metadata metadata)
    {
        const string template = "/swagger/{documentName}/swagger.json";
        var prefix = string.IsNullOrEmpty(metadata.EndpointPrefix) 
            ? "swagger" 
            : $"{metadata.EndpointPrefix}/swagger";
        app.UseSwagger(o =>
        {
            o.RouteTemplate = template;
        });
        app.UseSwaggerUI(o =>
        {
            o.DocumentTitle = metadata.Name;
            o.RoutePrefix = prefix;
            o.SwaggerEndpoint(template.Replace("{documentName}", DocumentName), DocumentName);
        });
    }
}