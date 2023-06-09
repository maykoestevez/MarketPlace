using System.Reflection;
using AutoMapper;

namespace MarketPlace.Application.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyingMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyingMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes().Where(t =>
                t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");

            methodInfo.Invoke(instance, new object?[] {this});
        }
        
    }
}