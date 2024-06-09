using System;
using System.Collections.Generic;

public class Row
{
    public Guid Id { get; set; } = Guid.NewGuid();              // Unique Row ID
    public int Number { get; set; }                             // Number of Row
    public List<Lane> Lanes { get; set; } = new List<Lane>();   // List of Lane objects
    public int PositionZ { get; set; }                          // ROS coordinate Z
    public Size Size { get; set; } = new Size();                // Height of Row (Non-nullable)
}
