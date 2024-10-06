using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace FastAcademy.Shared.Extensions;

public static class MapperExtensions
{
    private static IMapper _mapper = default!;
    
    public static void AddCoreMapper(this IServiceCollection services, IEnumerable<Assembly> assembly)
    {
        var configuration = new MapperConfiguration(
            cfg =>
            {
                cfg.AddMaps(assembly);
            });
        
        _mapper = configuration.CreateMapper();

        services.AddSingleton(_mapper);
    }
    
    public static TDestination MapTo<TDestination>(this object source)
    {
        return _mapper.Map<TDestination>(source);
    }
    
    public static TDestination MapTo<TDestination>(this object source, 
        Action<IMappingOperationOptions<object, TDestination>> options)
    {
        return _mapper.Map(source, options);
    }
    
    public static TDestination MapTo<TSource, TDestination>(this TSource source, 
        Action<IMappingOperationOptions<TSource, TDestination>> options)
    {
        return _mapper.Map(source, options);
    }
}