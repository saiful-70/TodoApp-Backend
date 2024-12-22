using SharpOutcome;
using SharpOutcome.Helpers.Contracts;
using SharpOutcome.Helpers.Enums;
using TodoApp.Entities;

namespace TodoApp.Application.Features.TaskItemFeatures;

public class TaskItemService : ITaskItemService
{
    private readonly IAppUnitOfWork _appUnitOfWork;

    public TaskItemService(IAppUnitOfWork appUnitOfWork)
    {
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task<ValueOutcome<Guid, IBadOutcome<HttpBadOutcomeTag>>> CreateAsync(TaskItemRequest dto
    )
    {
        var entity = new TaskItem
        {
            Id = Guid.CreateVersion7(),
            Title = dto.Title,
            Description = dto.Description,
            IsCompleted = dto.IsCompleted
        };
        await _appUnitOfWork.TaskItemRepository.CreateAsync(entity);
        await _appUnitOfWork.SaveAsync();

        return entity.Id;
    }
}