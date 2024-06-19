using Microsoft.AspNetCore.Mvc;
namespace ShelfLayoutManagement.Services;

[ApiController]
[Route("api/v1")]
public class ShelfController : ControllerBase
{
    [HttpGet("shelves")]
    public ActionResult<List<Shelf>> GetShelves()
    {
        return Ok(ShelfService.GetShelves());
    }

    [HttpGet("shelves/{shelfId}/cabinets")]
    public ActionResult<List<Cabinet>> GetCabinets(Guid shelfId)
    {
        return Ok(ShelfService.GetCabinets(shelfId));
    }

    [HttpGet("shelves/{shelfId}/cabinets/{cabinetId}/rows")]
    public ActionResult<List<Row>> GetRows(Guid shelfId, Guid cabinetId)
    {
        return Ok(ShelfService.GetRows(shelfId, cabinetId));
    }

    [HttpGet("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}/lanes")]
    public ActionResult<List<Lane>> GetLanes(Guid shelfId, Guid cabinetId, Guid rowId)
    {
        return Ok(ShelfService.GetLanes(shelfId, cabinetId, rowId));
    }


    [HttpGet("shelves/{shelfId}")]
    public ActionResult<Shelf> GetShelf(Guid shelfId)
    {
        
        Shelf shelf = ShelfService.GetShelf(shelfId);

        if (shelf == null)
        {
            return NotFound();
        }
        return Ok(shelf);
    }

    [HttpGet("shelves/{shelfId}/cabinets/{cabinetId}")]
    public ActionResult<Cabinet> GetCabinet(Guid shelfId, Guid cabinetId)
    {

        Cabinet cabinet = ShelfService.GetCabinet(shelfId, cabinetId);

        if (cabinet == null)
        {
            return NotFound();
        }

        return Ok(cabinet);
    }

    [HttpGet("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}")]
    public ActionResult<Row> GetRow(Guid shelfId, Guid cabinetId, Guid rowId)
    {

        Row row = ShelfService.GetRow(shelfId, cabinetId, rowId);

        if (row == null)
        {
            return NotFound();
        }

        return Ok(row);
    }

    [HttpGet("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}/lanes/{laneId}")]
    public ActionResult<Lane> GetLane(Guid shelfId, Guid cabinetId, Guid rowId, Guid laneId)
    {
        Lane lane = ShelfService.GetLane(shelfId, cabinetId, rowId, laneId);

        if (lane == null)
        {
            return NotFound();
        }

        return Ok(lane);
    }


    [HttpPost("shelves")]
    public ActionResult<Shelf> CreateShelf(Shelf shelf)
    {
        return Created("", ShelfService.CreateShelf(shelf));
    }

    [HttpPost("shelves/{shelfId}/cabinets")]
    public ActionResult<Cabinet> CreateCabinet(Guid shelfId, Cabinet cabinet)
    {
        Console.WriteLine($"Attempting to create cabinet with ID: {cabinet.Id}");
        return Created("", ShelfService.CreateCabinet(shelfId, cabinet));
    }

    [HttpPost("shelves/{shelfId}/cabinets/{cabinetId}/rows")]
    public ActionResult<Row> CreateRow(Guid shelfId, Guid cabinetId, Row row)
    {
        return Created("", ShelfService.CreateRow(shelfId, cabinetId, row));
    }

    [HttpPost("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}/lanes")]
    public ActionResult<Lane> CreateLane(Guid shelfId, Guid cabinetId, Guid rowId, Lane lane)
    {
        return Created("", ShelfService.CreateLane(shelfId, cabinetId, rowId, lane));
    }

    
    [HttpPut("shelves/{shelfId}")]
    public ActionResult<Shelf> UpdateShelf(Guid shelfId, Shelf shelf)
    {
        return Ok(ShelfService.UpdateShelf(shelfId, shelf));
    }

    [HttpPut("shelves/{shelfId}/cabinets/{cabinetId}")]
    public ActionResult<Cabinet> UpdateCabinet(Guid shelfId, Guid cabinetId, Cabinet cabinet)
    {
        return Ok(ShelfService.UpdateCabinet(shelfId, cabinetId, cabinet));
    }

    [HttpPut("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}")]
    public ActionResult<Row> UpdateRow(Guid shelfId, Guid cabinetId, Guid rowId, Row row)
    {
        return Ok(ShelfService.UpdateRow(shelfId, cabinetId, rowId, row));
    }

    [HttpPut("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}/lanes/{laneId}")]
    public ActionResult<Lane> UpdateLane(Guid shelfId, Guid cabinetId, Guid rowId, Guid laneId, Lane lane)
    {
        return Ok(ShelfService.UpdateLane(shelfId, cabinetId, rowId, laneId, lane));
    }


    [HttpDelete("shelves/{shelfId}")]
    public ActionResult DeleteShelf(Guid shelfId)
    {
        ShelfService.DeleteShelf(shelfId);
        return NoContent();
    }

    [HttpDelete("shelves/{shelfId}/cabinets/{cabinetId}")]
    public ActionResult DeleteCabinet(Guid shelfId, Guid cabinetId)
    {
        Console.WriteLine($"Attempting to delete cabinet with ID: {cabinetId}");
        ShelfService.DeleteCabinet(shelfId, cabinetId);
        return NoContent();
    }


    [HttpDelete("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}")]
    public ActionResult DeleteRow(Guid shelfId, Guid cabinetId, Guid rowId)
    {
        ShelfService.DeleteRow(shelfId, cabinetId, rowId);
        return NoContent();
    }

    [HttpDelete("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowId}/lanes/{laneId}")]
    public ActionResult DeleteLane(Guid shelfId, Guid cabinetId, Guid rowId, Guid laneId)
    {
        ShelfService.DeleteLane(shelfId, cabinetId, rowId, laneId);
        return NoContent();
    }

}