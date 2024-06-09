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

    [HttpGet("shelves/cabinets")]
    public ActionResult<List<Cabinet>> GetCabinets()
    {
        return Ok(ShelfService.GetCabinets());
    }

    [HttpGet("shelves/cabinets/rows")]
    public ActionResult<List<Row>> GetRows()
    {
        return Ok(ShelfService.GetRows());
    }

    [HttpGet("shelves/cabinets/rows/lanes")]
    public ActionResult<List<Lane>> GetLanes()
    {
        return Ok(ShelfService.GetLanes());
    }


    [HttpGet("shelves/{id}")]
    public ActionResult<Shelf> GetShelf(Guid id)
    {

        Shelf shelf = ShelfService.GetShelf(id);

        if (shelf == null)
        {
            return NotFound();
        }

        return Ok(shelf);
    }

    [HttpGet("shelves/cabinets/{id}")]
    public ActionResult<Cabinet> GetCabinet(Guid id)
    {

        Cabinet cabinet = ShelfService.GetCabinet(id);

        if (cabinet == null)
        {
            return NotFound();
        }

        return Ok(cabinet);
    }

    [HttpGet("shelves/rows/{id}")]
    public ActionResult<Row> GetRow(Guid id)
    {

        Row row = ShelfService.GetRow(id);

        if (row == null)
        {
            return NotFound();
        }

        return Ok(row);
    }

    [HttpGet("shelves/rows/lanes/{id}")]
    public ActionResult<Lane> GetLane(Guid id)
    {
        Lane lane = ShelfService.GetLane(id);

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

    //[HttpPost("shelves/cabinets")]
    //public ActionResult<Cabinet> CreateCabinet(Cabinet cabinet)
    //{
    //    return Created("", ShelfService.CreateCabinet(cabinet));
    //}

    //[HttpPost("shelves/cabinets/rows")]
    //public ActionResult<Row> CreateRow(Row row)
    //{
    //    return Created("", ShelfService.CreateRow(row));
    //}

    //[HttpPost("shelves/cabinets/rows/lanes")]
    //public ActionResult<Lane> CreateLane(Lane lane)
    //{
    //    return Created("", ShelfService.CreateLane(lane));
    //}


    [HttpPut("shelves/{id}")]
    public ActionResult<Shelf> UpdateShelf(Guid id, Shelf shelf)
    {
        return Ok(ShelfService.UpdateShelf(id, shelf));
    }

    [HttpPut("sshelves/cabinets/{id}")]
    public ActionResult<Cabinet> UpdateCabinet(Guid id, Cabinet cabinet)
    {
        return Ok(ShelfService.UpdateCabinet(id, cabinet));
    }

    [HttpPut("shelves/cabinets/rows/{id}")]
    public ActionResult<Row> UpdateRow(Guid id, Row row)
    {
        return Ok(ShelfService.UpdateRow(id, row));
    }

    [HttpPut("shelves/cabinets/rows/lanes/{id}")]
    public ActionResult<Lane> UpdateLane(Guid id, Lane lane)
    {
        return Ok(ShelfService.UpdateLane(id, lane));
    }


    [HttpDelete("shelves/{id}")]
    public ActionResult DeleteShelf(Guid id)
    {
        ShelfService.DeleteShelf(id);
        return NoContent();
    }

    [HttpDelete("shelves/cabinets/{id}")]
    public ActionResult DeleteCabinet(Guid id)
    {
        ShelfService.DeleteCabinet(id);
        return NoContent();
    }

    [HttpDelete("shelves/cabinets/rows/{id}")]
    public ActionResult DeleteRow(Guid id)
    {
        ShelfService.DeleteRow(id);
        return NoContent();
    }

    [HttpDelete("shelves/cabinets/rows/lanes/{id}")]
    public ActionResult DeleteLane(Guid id)
    {
        ShelfService.DeleteLane(id);
        return NoContent();
    }

}