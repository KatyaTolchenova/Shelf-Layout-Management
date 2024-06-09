using System;

public class Lane
{
    public Guid Id { get; set; } = Guid.NewGuid();      // Unique Lane ID
    public int Number { get; set; }                     // Number of lane
    public string JanCode { get; set; } = string.Empty; // SKU Jancode (Non-nullable property)
    public int Quantity { get; set; }                   // SKU Quantity
    public int PositionX { get; set; }                  // ROS coordinate X
}
