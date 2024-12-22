using TodoApp.Entities;
using TodoApp.Repositories;

namespace TodoApp.Infrastructure.Persistence.Repositories;

public class TaskGroupRepository: Repository<TaskGroup>, ITaskGroupRepository
{
    public TaskGroupRepository(TodoDbContext context) : base(context)
    {
    }
}