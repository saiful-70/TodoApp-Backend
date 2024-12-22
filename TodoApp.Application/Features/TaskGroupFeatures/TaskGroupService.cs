using SharpOutcome;
using SharpOutcome.Helpers.Contracts;
using SharpOutcome.Helpers.Enums;
using TodoApp.Application.Features.TaskItemFeatures;
using TodoApp.Entities;

namespace TodoApp.Application.Features.TaskGroupFeatures;

public class TaskGroupService: ITaskGroupService
{
    
    private readonly IAppUnitOfWork _appUnitOfWork;

    public TaskGroupService(IAppUnitOfWork appUnitOfWork)
    {
        _appUnitOfWork = appUnitOfWork;
    }
    
    public async Task<ValueOutcome<Guid, IBadOutcome<HttpBadOutcomeTag>>> CreateAsync(TaskGroupRequest dto
    )
    {
        var entity = new TaskGroup
        {
            Id = Guid.CreateVersion7(),
            Title = dto.Title
        };
        await _appUnitOfWork.TaskGroupRepository.CreateAsync(entity);
        await _appUnitOfWork.SaveAsync();

        return entity.Id;
    }
}