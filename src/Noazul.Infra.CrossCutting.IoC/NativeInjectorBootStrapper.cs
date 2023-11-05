using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Noazul.Domain.Interfaces;
using Noazul.Infra.CrossCutting.Bus.Behaviors;
using Noazul.Infra.Data.Context;
using Noazul.Infra.Data.Repository;

namespace Noazul.Infra.CrossCutting.IoC;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Domain Bus (Mediator)
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

        // Domain - UseCases

        // Infra - Data
        services.AddScoped<NoazulContext>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}
