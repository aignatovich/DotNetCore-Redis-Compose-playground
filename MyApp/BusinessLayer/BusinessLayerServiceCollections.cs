using Microsoft.Extensions.DependencyInjection;

public static class BusinessLayerServiceCollections
{
    public static IServiceCollection RegisterDependencies(IServiceCollection serviceCollection)
    {
        return DataLayerServiceCollections.RegisterDependencies(serviceCollection);
    }
}