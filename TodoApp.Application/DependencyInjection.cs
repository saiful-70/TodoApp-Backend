using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TodoApp.Application.Features.TaskGroupFeatures;
using TodoApp.Application.Features.TaskItemFeatures;

namespace TodoApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.TryAddScoped<ITaskItemService, TaskItemService>();
        services.TryAddScoped<ITaskGroupService, TaskGroupService>();
        return services;
    }
}