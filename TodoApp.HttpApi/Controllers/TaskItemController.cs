using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Features.TaskItemFeatures;
using TodoApp.Entities;

namespace TodoApp.HttpApi.Controllers;

[Route("api/[controller]s")]
[ApiController]
[Consumes("application/json")]
[Produces("application/json")]
public class TaskItemController(ITaskItemService taskItemService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TaskItemRequest taskItemRequest)
    {
        var result = await taskItemService.CreateAsync(taskItemRequest);

        if (result.TryPickGoodOutcome(out var data))
        {
            return Ok(data);
        }

        return BadRequest();
    }
}