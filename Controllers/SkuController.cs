using Microsoft.AspNetCore.Mvc;
namespace ShelfLayoutManagement.Services;

[ApiController]
[Route("api/v1")]
public class SkuController : ControllerBase
{
    [HttpPost("skus/add")]
    public ActionResult<LaneInfo> AddSku([FromForm] Guid laneId, [FromForm] int count)
    {
        Console.WriteLine("count -> " + count);
        return Ok(ShelfService.AddSku(laneId, count)); 
    }

    [HttpPost("skus/remove")]
    public ActionResult<LaneInfo> RemoveSku([FromForm] Guid laneId, [FromForm] int count)
    {
        return Ok(ShelfService.RemoveSku(laneId, count));
    }

    [HttpPost("skus/move")]
    public ActionResult MoveSku([FromForm] Guid sourceLaneId, [FromForm] Guid targetLaneId, [FromForm] int count)
    {
        ShelfService.MoveSku(sourceLaneId, targetLaneId, count);
        return NoContent();
    }
}
