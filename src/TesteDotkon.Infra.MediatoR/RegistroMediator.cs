using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TesteDotkon.Infra.MediatoR;

public static class RegistroMediator
{
    public static IServiceCollection AddMediator(this IServiceCollection services, Assembly[] assemblies)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

        return services;
    }
}
