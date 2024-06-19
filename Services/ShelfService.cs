
public static class ShelfService
{
    private static Dictionary<Guid, Shelf> shelves = new Dictionary<Guid, Shelf>();
    private static Dictionary<Guid, LaneInfo> laneInfos = new Dictionary<Guid, LaneInfo>();

    public static List<Shelf> GetShelves()
    { 
        return new List<Shelf>(shelves.Values);
    }

    public static List<Cabinet> GetCabinets(Guid shelfId)
    {
        Shelf shelf = GetShelf(shelfId);
        if (shelf == null)
        {
            throw new Exception("Shelf with id " + shelfId + " not found");
        }
        
        return new List<Cabinet>(shelf.Cabinets);
    }

    public static List<Row> GetRows(Guid shelfId, Guid cabinetId)
    {
        Cabinet cabinet = GetCabinet(shelfId, cabinetId);

        if (cabinet == null)
        {
            throw new Exception("Cabinet with id " + cabinetId + " not found");
        }

        return new List<Row>(cabinet.Rows);
    }

    public static List<Lane> GetLanes(Guid shelfId, Guid cabinetId, Guid rowId)
    {
        Row row = GetRow(shelfId, cabinetId, rowId);

        if (row == null)
        {
            throw new Exception("Row with id " + rowId + " not found");
        }
     
        return new List<Lane>(row.Lanes);
    }

    public static Shelf GetShelf(Guid id)
    {
        if (shelves.ContainsKey(id))
        {
            return shelves[id];
        }
        else
        {
            return null;
        }
    }

    public static Cabinet GetCabinet(Guid shelfId, Guid id)
    {
        Shelf shelf = GetShelf(shelfId);
        if (shelf == null)
        {
            throw new Exception("Shelf with id " + shelfId + " not found");
        }

        foreach (var cabinet in shelf.Cabinets)
        {
            if (cabinet.Id == id)
            { 
                return cabinet;
            }
        }
        return null;
    }

    public static Row GetRow(Guid shelfId, Guid cabinetId, Guid id)
    {
        Cabinet cabinet = GetCabinet(shelfId, cabinetId);

        if (cabinet == null)
        {
            throw new Exception("Cabinet with id " + cabinetId + " not found");
        }

        foreach (var row in cabinet.Rows)
        {
            if (row.Id == id)
            {
                return row;
            }
        }
        return null;
    }

    public static Lane GetLane(Guid shelfId, Guid cabinetId, Guid rowId, Guid id)
    {
        Row row = GetRow(shelfId, cabinetId, rowId);
        if (row == null)
        {
            throw new Exception("Row with id " + rowId + " not found");
        }

        foreach (var lane in row.Lanes)
        {
            if (lane.Id == id)
            {
                return lane;
            }
        }
        return null;
    }

    public static Shelf CreateShelf(Shelf shelf)
    {
        shelves.Add(shelf.Id, shelf);
        return shelf;
    }

    public static Cabinet CreateCabinet(Guid shelfId, Cabinet cabinet)
    {
        Shelf shelf = GetShelf(shelfId);
        if (shelf == null)
        {
            throw new Exception("Shelf with id " + shelfId + " not found");
        }

        shelf.Cabinets.Add(cabinet);
        return cabinet;
    }

    public static Row CreateRow(Guid shelfId, Guid cabinetId, Row row)
    {
        Cabinet cabinet = GetCabinet(shelfId, cabinetId);
        if (cabinet == null)
        {
            throw new Exception("Cabinet with id " + cabinetId + " not found");
        }

        cabinet.Rows.Add(row);
        return row;
    }

    public static Lane CreateLane(Guid shelfId, Guid cabinetId, Guid rowId, Lane lane)
    {
        Row row = GetRow(shelfId, cabinetId, rowId);
        if (row == null)
        {
            throw new Exception("Row with id " + rowId + " not found");
        }

        row.Lanes.Add(lane);
        return lane;
    }

    public static void DeleteShelf(Guid id)
    {
        if(shelves.ContainsKey(id)) 
        {
            shelves.Remove(id);
        }
    }

    public static void DeleteCabinet(Guid shelfId, Guid id)
    {
        Shelf shelf = GetShelf(shelfId);
        if (shelf == null)
        {
            throw new Exception("Shelf with id " + shelfId + " not found");
        }

        Cabinet cabinet = null;

        foreach (var cabinet0 in shelf.Cabinets)
        {
            if (cabinet0.Id == id)
            {
                cabinet = cabinet0;
                break;
            }
        }
        shelf.Cabinets.Remove(cabinet);
    }

    public static void DeleteRow(Guid shelfId, Guid cabinetId, Guid id)
    {
        Cabinet cabinet = GetCabinet(shelfId, cabinetId);
        if (cabinet == null)
        {
            throw new Exception("Cabinet with id " + cabinetId + " not found");
        }

        Row row = null;

        foreach (var row0 in cabinet.Rows)
        {
            if (row0.Id == id)
            {
                row = row0;
                break;
            }
        }
        cabinet.Rows.Remove(row);
    }

    public static void DeleteLane(Guid shelfId, Guid cabinetId, Guid rowId, Guid id)
    {
        Row row = GetRow(shelfId, cabinetId, rowId);
        if (row == null)
        {
            throw new Exception("Row with id " + rowId + " not found");
        }

        Lane lane = null;

        foreach (var lane0 in row.Lanes)
        {
            if (lane0.Id == id)
            {
                lane = lane0;
                break;
            }
        }
        row.Lanes.Remove(lane);
    }

    public static Shelf UpdateShelf(Guid id, Shelf shelf)
    {
        shelf.Id = id;
        DeleteShelf(id);
        CreateShelf(shelf);
        return shelf;
    }

    public static Cabinet UpdateCabinet(Guid shelfId, Guid id, Cabinet cabinet)
    {
        cabinet.Id = id;
        DeleteCabinet(shelfId, id);
        CreateCabinet(shelfId, cabinet);
        return cabinet;
    }

    public static Row UpdateRow(Guid shelfId, Guid cabinetId, Guid id, Row row)
    {
        row.Id = id;
        DeleteRow(shelfId, cabinetId, id);
        CreateRow(shelfId, cabinetId, row);
        return row;
    }

    public static Lane UpdateLane(Guid shelfId, Guid cabinetId, Guid rowId, Guid id, Lane lane)
    {
        lane.Id = id;
        DeleteLane(shelfId, cabinetId, rowId, id);
        CreateLane(shelfId, cabinetId, rowId, lane);
        return lane;
    }


    public static LaneInfo AddSku(Guid shelfId, Guid cabinetId, Guid rowId, Guid laneId, int count)
    {
        CheckAddSkuPrecondtions(shelfId, cabinetId, rowId, laneId, count);

        LaneInfo laneInfo = laneInfos[laneId];

        laneInfo.Count += count;
        
        return laneInfo;
    }

    public static LaneInfo RemoveSku(Guid shelfId, Guid cabinetId, Guid rowId, Guid laneId, int count)
    {

        CheckRemoveSkuPrecondtions(shelfId, cabinetId, rowId, laneId, count);

        LaneInfo laneInfo = laneInfos[laneId];

        laneInfo.Count -= count;

        return laneInfo;
    }

    public static void MoveSku(Guid sourceShelfId, Guid sourceCabinetId, Guid sourceRowId, Guid sourceLaneId, Guid targetShelfId, Guid targetCabinetId, Guid targetRowId, Guid targetLaneId, int count)
    {
        CheckMoveSkuPrecondtions(sourceShelfId, sourceCabinetId, sourceRowId, sourceLaneId, targetShelfId, targetCabinetId, targetRowId, targetLaneId, count);

        LaneInfo sourceLaneInfo = laneInfos[sourceLaneId];

        sourceLaneInfo.Count -= count;

        LaneInfo targetLaneInfo = laneInfos[targetLaneId];

        targetLaneInfo.Count += count;

        Console.WriteLine("source lane -> " + sourceLaneInfo.Count);
        Console.WriteLine("target lane -> " + targetLaneInfo.Count);
    }

    private static void CheckAddSkuPrecondtions(Guid shelfId, Guid cabinetId, Guid rowId, Guid laneId, int count)
    {

        Lane lane = GetLane(shelfId, cabinetId, rowId, laneId);

        if (lane == null)
        {
            throw new Exception("Lane with id " + laneId + " not found");
        }

        LaneInfo laneInfo = null;

        if (laneInfos.ContainsKey(laneId))
        {
            laneInfo = laneInfos[laneId];
        }
        else
        {
            laneInfo = new LaneInfo();
            laneInfo.LaneId = laneId;
            laneInfo.Count = 0;
            laneInfos.Add(laneInfo.LaneId, laneInfo);
        }

        if (lane.Quantity < laneInfo.Count + count)
        {
            throw new Exception("Lane quantity " + lane.Quantity + " is exceeded");
        }
    }

    private static void CheckRemoveSkuPrecondtions(Guid shelfId, Guid cabinetId, Guid rowId, Guid laneId, int count)
    {
        Lane lane = GetLane(shelfId, cabinetId, rowId, laneId);

        if (lane == null)
        {
            throw new Exception("Lane with id " + laneId + " not found");
        }

        LaneInfo laneInfo = null;

        if (laneInfos.ContainsKey(laneId))
        {
            laneInfo = laneInfos[laneId];
        }
        else
        {
            laneInfo = new LaneInfo();
            laneInfo.LaneId = laneId;
            laneInfo.Count = 0;
            laneInfos.Add(laneInfo.LaneId, laneInfo);
        }

        if (laneInfo.Count < count)
        {
            throw new Exception("Lane with id " + laneId + " contains insufficient count");
        }
    }

    private static void CheckMoveSkuPrecondtions(Guid sourceShelfId, Guid sourceCabinetId, Guid sourceRowId, Guid sourceLaneId, Guid targetShelfId, Guid targetCabinetId, Guid targetRowId, Guid targetLaneId, int count)
    {
        CheckRemoveSkuPrecondtions(sourceShelfId, sourceCabinetId, sourceRowId, sourceLaneId, count);
        CheckAddSkuPrecondtions(targetShelfId, targetCabinetId, targetRowId, targetLaneId, count);

        Lane sourceLane = GetLane(sourceShelfId, sourceCabinetId, sourceRowId, sourceLaneId);
        Lane targetLane = GetLane(targetShelfId, targetCabinetId, targetRowId, targetLaneId);

        if (sourceLane.JanCode != targetLane.JanCode)
        {
            throw new Exception("Source lane jan code " + sourceLane.JanCode + " not match target jan code " + targetLane.JanCode);
        }
    }

}