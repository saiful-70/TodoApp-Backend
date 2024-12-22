namespace TodoApp.Application.Features.TaskItemFeatures;

public record TaskItemRequest
{
    public required string Title { get; init; }
    public required string? Description { get; init; }
    public required bool IsCompleted { get; init; }
}