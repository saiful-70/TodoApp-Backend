namespace TodoApp.Entities;

public class MapTaskItemWithGroup
{
    public required Guid GroupId { get; init; }
    public required Guid TaskId { get; init; }
}