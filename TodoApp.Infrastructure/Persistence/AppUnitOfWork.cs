using TodoApp.Application;
using TodoApp.Repositories;

namespace TodoApp.Infrastructure.Persistence;

public class AppUnitOfWork : UnitOfWork, IAppUnitOfWork
{
    public AppUnitOfWork(TodoDbContext dbContext, ITaskItemRepository taskItemRepository,
        ITaskGroupRepository taskGroupRepository) : base(dbContext)
    {
        TaskItemRepository = taskItemRepository;
        TaskGroupRepository = taskGroupRepository;
    }

    public ITaskItemRepository TaskItemRepository { get; }
    public ITaskGroupRepository TaskGroupRepository { get; }
}