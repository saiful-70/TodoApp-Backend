using TodoApp.Entities;
using TodoApp.Repositories;

namespace TodoApp.Infrastructure.Persistence.Repositories;

public class TaskItemRepository: Repository<TaskItem>, ITaskItemRepository
{
    public TaskItemRepository(TodoDbContext context) : base(context)
    {
    }
}