
public static class ShelfService
{
    private static Dictionary<Guid, Shelf> shelves = new Dictionary<Guid, Shelf>();
    private static Dictionary<Guid, Cabinet> cabinets = new Dictionary<Guid, Cabinet>();
    private static Dictionary<Guid, Row> rows = new Dictionary<Guid, Row>();
    private static Dictionary<Guid, Lane> lanes = new Dictionary<Guid, Lane>();
    private static Dictionary<Guid, LaneInfo> laneInfos = new Dictionary<Guid, LaneInfo>();

    public static List<Shelf> GetShelves()
    { 
        return new List<Shelf>(shelves.Values);
    }

    public static List<Cabinet> GetCabinets()
    {
        return new List<Cabinet>(cabinets.Values);
    }

    public static List<Row> GetRows()
    {
        return new List<Row>(rows.Values);
    }

    public static List<Lane> GetLanes()
    {
        return new List<Lane>(lanes.Values);
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

    public static Cabinet GetCabinet(Guid id)
    {
        if (cabinets.ContainsKey(id))
        {
            return cabinets[id]; 
        }
        else
        {
            return null;
        }
    }

    public static Row GetRow(Guid id)
    {
        if (rows.ContainsKey(id))
        {
            return rows[id];
        }
        else 
        { 
            return null; 
        }
    }

    public static Lane GetLane(Guid id)
    {
        if (lanes.ContainsKey(id))
        {
            return lanes[id];
        }
        else
        {
            return null;
        }
    }

    public static Shelf CreateShelf(Shelf shelf)
    {
        Console.WriteLine("===== create shelf");
        shelves.Add(shelf.Id, shelf);

        foreach (var cabinet in shelf.Cabinets)
        {
            CreateCabinet(cabinet);
        }
        dump();
        return shelf;

    }

    public static Cabinet CreateCabinet(Cabinet cabinet)
    {
        Console.WriteLine("===== create cabinet");
        cabinets.Add(cabinet.Id, cabinet);
        foreach (var row in cabinet.Rows)
        {
            CreateRow(row);
        }
        dump();
        return cabinet;
    }

    public static Row CreateRow(Row row)
    {
        Console.WriteLine("===== create row");
        rows.Add(row.Id, row);
        foreach (var lane in row.Lanes)
        {
            CreateLane(lane);
        }
        dump();
        return row;
    }

    public static Lane CreateLane(Lane lane)
    {
        Console.WriteLine("===== create lane");
        lanes.Add(lane.Id, lane);
        dump();
        return lane;
    }

    public static void DeleteShelf(Guid id)
    {
        Console.WriteLine("delete");
        if(shelves.ContainsKey(id)) {
        Shelf shelf = shelves[id];
            shelves.Remove(id);
            foreach (var cabinet in shelf.Cabinets)
            {
                DeleteCabinet(cabinet.Id);
            }
        }
        dump();
    }

    public static void DeleteCabinet(Guid id)
    {
        Console.WriteLine("delete cabinet");
        if (cabinets.ContainsKey(id))
        {
            Cabinet cabinet = cabinets[id];
            cabinets.Remove(id);

            foreach (var row in cabinet.Rows)
            {
                DeleteRow(row.Id);
            }
        }
        dump();
    }

    public static void DeleteRow(Guid id)
    {
        Console.WriteLine("delete row");
        if (rows.ContainsKey(id))
        {
            Row row = rows[id];
            rows.Remove(id);

            foreach (var lane in row.Lanes)
            {
                lanes.Remove(lane.Id);
            }
        }
        dump();
    }

    public static void DeleteLane(Guid id)
    {
        Console.WriteLine("delete lane");
        if (lanes.ContainsKey(id))
        {
            Lane lane = lanes[id];
            lanes.Remove(lane.Id);
        }
        dump();
    }

    public static Shelf UpdateShelf(Guid id, Shelf shelf)
    {
        shelf.Id = id;
        DeleteShelf(id);
        CreateShelf(shelf);
        return shelf;
    }

    public static Cabinet UpdateCabinet(Guid id, Cabinet cabinet)
    {
        cabinet.Id = id;
        DeleteCabinet(id);
        CreateCabinet(cabinet);
        return cabinet;
    }

    public static Row UpdateRow(Guid id, Row row)
    {
        row.Id = id;
        DeleteRow(id);
        CreateRow(row);
        return row;
    }

    public static Lane UpdateLane(Guid id, Lane lane)
    {
        lane.Id = id;
        DeleteLane(id);
        CreateLane(lane);
        return lane;
    }

    public static LaneInfo AddSku(Guid laneId, int count)
    {
        CheckAddSkuPrecondtions(laneId, count);

        LaneInfo laneInfo = laneInfos[laneId];

        laneInfo.Count += count;

        return laneInfo;
    }

    public static LaneInfo RemoveSku(Guid laneId, int count)
    {

        CheckRemoveSkuPrecondtions(laneId, count);

        LaneInfo laneInfo = laneInfos[laneId];

        laneInfo.Count -= count;

        return laneInfo;
    }

    private static void CheckAddSkuPrecondtions(Guid laneId, int count) {

        Lane lane = GetLane(laneId);

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

    private static void CheckRemoveSkuPrecondtions(Guid laneId, int count)
    {
        Lane lane = GetLane(laneId);

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

    private static void CheckMoveSkuPrecondtions(Guid sourceLaneId, Guid targetLaneId, int count)
    {
        CheckRemoveSkuPrecondtions(sourceLaneId, count);
        CheckAddSkuPrecondtions(targetLaneId, count);

        Lane sourceLane = lanes[sourceLaneId];
        Lane targetLane = lanes[targetLaneId];

        if (sourceLane.JanCode != targetLane.JanCode)
        {
            throw new Exception("Source lane jan code " + sourceLane.JanCode + " not match target jan code " + targetLane.JanCode);
        }
    }

    public static void MoveSku(Guid sourceLaneId, Guid targetLaneId, int count)
    {
        CheckMoveSkuPrecondtions(sourceLaneId, targetLaneId, count);

        LaneInfo sourceLaneInfo = laneInfos[sourceLaneId];

        sourceLaneInfo.Count -= count;

        LaneInfo targetLaneInfo = laneInfos[targetLaneId];

        targetLaneInfo.Count += count;

        Console.WriteLine("source lane -> " + sourceLaneInfo.Count);
        Console.WriteLine("target lane -> " + targetLaneInfo.Count);
    }

    private static void dump()
    {
        Console.WriteLine("shelves -> " + shelves.Count);
        Console.WriteLine("cabients -> " + cabinets.Count);
        Console.WriteLine("rows -> " + rows.Count);
        Console.WriteLine("lanes -> " + lanes.Count);

    }
}