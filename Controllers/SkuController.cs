using Microsoft.AspNetCore.Mvc;
namespace ShelfLayoutManagement.Services;

[ApiController]
[Route("api/v1")]
public class SkuController : ControllerBase
{
    [HttpPost("skus/add")]
    public ActionResult<LaneInfo> AddSku([FromForm] Guid shelfId, [FromForm] Guid cabinetId, [FromForm] Guid rowId, [FromForm] Guid laneId, [FromForm] int count)
    {
        Console.WriteLine("count -> " + count);
        return Ok(ShelfService.AddSku(shelfId, cabinetId, rowId, laneId, count));
    }

    [HttpPost("skus/remove")]
    public ActionResult<LaneInfo> RemoveSku([FromForm] Guid shelfId, [FromForm] Guid cabinetId, [FromForm] Guid rowId, [FromForm] Guid laneId, [FromForm] int count)
    {
        return Ok(ShelfService.RemoveSku(shelfId, cabinetId, rowId, laneId, count));
    }

    [HttpPost("skus/move")]
    public ActionResult MoveSku([FromForm] Guid sourceShelfId, [FromForm] Guid sourceCabinetId, [FromForm] Guid sourceRowId, [FromForm] Guid sourceLaneId, [FromForm] Guid targetShelfId, [FromForm] Guid targetCabinetId, [FromForm] Guid targetRowId, [FromForm] Guid targetLaneId, [FromForm] int count)
    {
        ShelfService.MoveSku(sourceShelfId, sourceCabinetId, sourceRowId, sourceLaneId, targetShelfId, targetCabinetId, targetRowId, targetLaneId, count);
        return NoContent();
    }
}
