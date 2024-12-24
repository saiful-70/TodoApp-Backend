using SharpOutcome;
using SharpOutcome.Helpers;
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


    public async Task<ICollection<TaskItem>> GetAllAsync(CancellationToken ct)
    {
        return await _appUnitOfWork
            .TaskItemRepository
            .GetAllAsync(false, cancellationToken: ct);
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

    public async Task<ValueOutcome<Guid, IBadOutcome<HttpBadOutcomeTag>>> UpdateAsync(Guid id, TaskItemRequest dto)
    {
        var entity = await _appUnitOfWork
            .TaskItemRepository
            .GetOneAsync(x => x.Id == id);

        if (entity is null)
        {
            return new HttpBadOutcome(HttpBadOutcomeTag.NotFound);
        }

        entity.Title = dto.Title;
        entity.Description = dto.Description;
        entity.IsCompleted = dto.IsCompleted;

        await _appUnitOfWork.TaskItemRepository.UpdateAsync(entity);

        await _appUnitOfWork.SaveAsync();

        return entity.Id;
    }
}