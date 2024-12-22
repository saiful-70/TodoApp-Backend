using TodoApp.Repositories;

namespace TodoApp.Application;

public interface IAppUnitOfWork: IUnitOfWork
{
    ITaskItemRepository TaskItemRepository { get; }
    ITaskGroupRepository TaskGroupRepository { get; }
}