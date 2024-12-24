using SharpOutcome;
using SharpOutcome.Helpers.Contracts;
using SharpOutcome.Helpers.Enums;
using TodoApp.Entities;

namespace TodoApp.Application.Features.TaskItemFeatures;

public interface ITaskItemService
{
    Task<ICollection<TaskItem>> GetAllAsync(CancellationToken ct);
    Task<ValueOutcome<Guid, IBadOutcome<HttpBadOutcomeTag>>> CreateAsync(TaskItemRequest dto);
    Task<ValueOutcome<Guid, IBadOutcome<HttpBadOutcomeTag>>> UpdateAsync(Guid id, TaskItemRequest dto);
}