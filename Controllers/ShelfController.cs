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
    public ActionResult<List<Cabinet>> GetCabinets()
    {
        return Ok(ShelfService.GetCabinets());
    }

    [HttpGet("shelves/{shelfId}/cabinets/{cabinetId}/rows")]
    public ActionResult<List<Row>> GetRows()
    {
        return Ok(ShelfService.GetRows());
    }

    [HttpGet("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}/lanes")]
    public ActionResult<List<Lane>> GetLanes()
    {
        return Ok(ShelfService.GetLanes());
    }


    [HttpGet("shelves/{shelfd}")]
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
    public ActionResult<Cabinet> GetCabinet(Guid cabinetId)
    {

        Cabinet cabinet = ShelfService.GetCabinet(cabinetId);

        if (cabinet == null)
        {
            return NotFound();
        }

        return Ok(cabinet);
    }

    [HttpGet("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}")]
    public ActionResult<Row> GetRow(Guid rowId)
    {

        Row row = ShelfService.GetRow(rowId);

        if (row == null)
        {
            return NotFound();
        }

        return Ok(row);
    }

    [HttpGet("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}/lanes/{laneId}")]
    public ActionResult<Lane> GetLane(Guid laneId)
    {
        Lane lane = ShelfService.GetLane(laneId);

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
    public ActionResult<Cabinet> CreateCabinet(Cabinet cabinet)
    {
        Console.WriteLine($"Attempting to create cabinet with ID: {cabinet.Id}");
        return Created("", ShelfService.CreateCabinet(cabinet));
    }

    [HttpPost("shelves/{shelfId}/cabinets/{cabinetId}/rows")]
    public ActionResult<Row> CreateRow(Row row)
    {
        return Created("", ShelfService.CreateRow(row));
    }

    [HttpPost("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}/lanes")]
    public ActionResult<Lane> CreateLane(Lane lane)
    {
        return Created("", ShelfService.CreateLane(lane));
    }

    
    [HttpPut("shelves/{shelfId}")]
    public ActionResult<Shelf> UpdateShelf(Guid shelfId, Shelf shelf)
    {
        return Ok(ShelfService.UpdateShelf(shelfId, shelf));
    }

    [HttpPut("shelves/{shelfId}/cabinets/{cabinetId}")]
    public ActionResult<Cabinet> UpdateCabinet(Guid cabinetId, Cabinet cabinet)
    {
        return Ok(ShelfService.UpdateCabinet(cabinetId, cabinet));
    }

    [HttpPut("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}")]
    public ActionResult<Row> UpdateRow(Guid rowId, Row row)
    {
        return Ok(ShelfService.UpdateRow(rowId, row));
    }

    [HttpPut("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}/lanes/{laneId}")]
    public ActionResult<Lane> UpdateLane(Guid laneId, Lane lane)
    {
        return Ok(ShelfService.UpdateLane(laneId, lane));
    }


    [HttpDelete("shelves/{shelfId}")]
    public ActionResult DeleteShelf(Guid shelfId)
    {
        ShelfService.DeleteShelf(shelfId);
        return NoContent();
    }

    [HttpDelete("shelves/{shelfId}/cabinets/{cabinetId}")]
    public ActionResult DeleteCabinet(Guid cabinetId)
    {
        Console.WriteLine($"Attempting to delete cabinet with ID: {cabinetId}");
        ShelfService.DeleteCabinet(cabinetId);
        return NoContent();
    }


    [HttpDelete("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}")]
    public ActionResult DeleteRow(Guid rowId)
    {
        ShelfService.DeleteRow(rowId);
        return NoContent();
    }

    [HttpDelete("shelves/{shelfId}/cabinets/{cabinetId}/rows/{rowsId}/lanes/{laneId}")]
    public ActionResult DeleteLane(Guid laneId)
    {
        ShelfService.DeleteLane(laneId);
        return NoContent();
    }

}