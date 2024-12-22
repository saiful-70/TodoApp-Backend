namespace TodoApp.Application.Features.TaskGroupFeatures;

public record TaskGroupRequest
{
    public required string Title { get; init; }
}