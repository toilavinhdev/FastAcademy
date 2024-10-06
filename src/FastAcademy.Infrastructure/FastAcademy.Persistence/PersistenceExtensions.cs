using System.Reflection;
using FastAcademy.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace FastAcademy.Persistence;

public static class PersistenceExtensions
{
    public static Assembly Assembly => typeof(PersistenceExtensions).Assembly;
    
    public static void AddPersistenceServices(this IServiceCollection services, AppSettings appSettings)
    {
            
    }
}