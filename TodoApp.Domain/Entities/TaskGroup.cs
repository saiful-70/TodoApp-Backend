namespace TodoApp.Entities;

public class TaskGroup
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
}