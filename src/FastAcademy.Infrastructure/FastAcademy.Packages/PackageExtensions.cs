using System.Reflection;
using FastAcademy.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace FastAcademy.Packages;

public static class PackagesExtensions
{
    public static Assembly Assembly { get; } = typeof(PackagesExtensions).Assembly;
    
    public static void AddPackagesServices(this IServiceCollection services, AppSettings appSettings)
    {
        
    }
}