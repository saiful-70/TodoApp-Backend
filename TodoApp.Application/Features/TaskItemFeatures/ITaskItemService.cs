using SharpOutcome;
using SharpOutcome.Helpers.Contracts;
using SharpOutcome.Helpers.Enums;

namespace TodoApp.Application.Features.TaskItemFeatures;

public interface ITaskItemService
{
    Task<ValueOutcome<Guid, IBadOutcome<HttpBadOutcomeTag>>> CreateAsync(TaskItemRequest dto);
}