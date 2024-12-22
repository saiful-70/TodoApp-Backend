using SharpOutcome;
using SharpOutcome.Helpers.Contracts;
using SharpOutcome.Helpers.Enums;

namespace TodoApp.Application.Features.TaskGroupFeatures;

public interface ITaskGroupService
{
    Task<ValueOutcome<Guid, IBadOutcome<HttpBadOutcomeTag>>> CreateAsync(TaskGroupRequest dto);
}