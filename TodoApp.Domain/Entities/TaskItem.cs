namespace TodoApp.Entities;

public class TaskItem
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public required string? Description { get; set; }
    public required bool IsCompleted { get; set; }
}