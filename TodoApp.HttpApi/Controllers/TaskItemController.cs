using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.TaskItemFeatures;
using TodoApp.Entities;

namespace TodoApp.HttpApi.Controllers;

[Route("api/[controller]s")]
[ApiController]
[Consumes("application/json")]
[Produces("application/json")]
public class TaskItemController : ControllerBase
{
    private readonly ITaskItemService _taskItemService;

    public TaskItemController(ITaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _taskItemService.GetAllAsync(HttpContext.RequestAborted);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaskItemRequest taskItemRequest)
    {
        var result = await _taskItemService.CreateAsync(taskItemRequest);

        if (result.TryPickGoodOutcome(out var data))
        {
            return Ok(data);
        }

        return BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] TaskItemRequest taskItemRequest)
    {
        var result = await _taskItemService.UpdateAsync(id, taskItemRequest);

        if (result.TryPickGoodOutcome(out var data))
        {
            return Ok(data);
        }

        return BadRequest();
    }
}