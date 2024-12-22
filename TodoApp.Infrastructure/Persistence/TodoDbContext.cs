using Microsoft.EntityFrameworkCore;
using TodoApp.Entities;

namespace TodoApp.Infrastructure.Persistence;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
    }
    public DbSet<TaskItem> TaskItems
    {
        get { return Set<TaskItem>(); }
    }

    public DbSet<MapTaskItemWithGroup> MapTaskItemWithGroups
    {
        get { return Set<MapTaskItemWithGroup>(); }
    }

    public DbSet<TaskGroup> TaskGroups
    {
        get { return Set<TaskGroup>(); }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDbContext).Assembly);
    }
}