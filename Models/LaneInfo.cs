using System;

public class LaneInfo
{
    public Guid Id { get; set; } = Guid.NewGuid();      // Unique Lane ID
    public Guid LaneId { get; set; }                    // Lane Id
    public int Count { get; set; }                      // Q'ty of loaded SKU
}
