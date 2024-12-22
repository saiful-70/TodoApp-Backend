using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TodoApp.Application;
using TodoApp.Infrastructure.Persistence;
using TodoApp.Infrastructure.Persistence.Repositories;
using TodoApp.Repositories;

namespace TodoApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.TryAddScoped<ITaskItemRepository, TaskItemRepository>();
        services.TryAddScoped<ITaskGroupRepository, TaskGroupRepository>();
        services.TryAddScoped<IAppUnitOfWork, AppUnitOfWork>();
        return services;
    }
}