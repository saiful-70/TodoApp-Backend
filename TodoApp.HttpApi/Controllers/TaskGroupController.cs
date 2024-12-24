using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.TaskGroupFeatures;
using TodoApp.Application.Features.TaskItemFeatures;

namespace TodoApp.HttpApi.Controllers;

[Route("api/[controller]s")]
[ApiController]
[Consumes("application/json")]
[Produces("application/json")]
public class TaskGroupController : ControllerBase
{
    private readonly ITaskGroupService _taskGroupService;

    public TaskGroupController(ITaskGroupService taskGroupService)
    {
        _taskGroupService = taskGroupService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TaskGroupRequest taskGroupRequest)
    {
        var result = await _taskGroupService.CreateAsync(taskGroupRequest);

        if (result.TryPickGoodOutcome(out var data))
        {
            return Ok(data);
        }

        return BadRequest();
    }

    // [HttpPut]
    // public async Task<IActionResult> Put([FromBody] TaskGroupRequest taskGroupRequest)
    // {
    //     
    // }
}