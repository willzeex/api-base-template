using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;
using Noazul.Domain.Commands;
using Noazul.Domain.Core.Events;
using Noazul.Domain.Events;
using Noazul.Domain.Interfaces;
using Noazul.Infra.CrossCutting.Bus;
using Noazul.Infra.Data.Context;
using Noazul.Infra.Data.EventSourcing;
using Noazul.Infra.Data.Repository;
using Noazul.Infra.Data.Repository.EventSourcing;

namespace Noazul.Infra.CrossCutting.IoC;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, InMemoryBus>();

        // Domain - Events
        services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
        services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
        services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

        // Domain - Commands
        services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>();
        services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>();

        // Infra - Data
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<NoazulContext>();

        // Infra - Data EventSourcing
        services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
        services.AddScoped<IEventStore, SqlEventStore>();
        services.AddScoped<EventStoreContext>();
    }
}
