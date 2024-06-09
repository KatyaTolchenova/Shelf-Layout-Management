using System;
using System.Collections.Generic;

public class Cabinet
{
    public Guid Id { get; set; } = Guid.NewGuid();              // Unique Row ID
    public int Number { get; set; }                             // Number of Cabinet
    public List<Row> Rows { get; set; } = new List<Row>();      // List of Row objects
    public Position Position { get; set; } = new Position();    // Position object (Non-nullable)
    public Size Size { get; set; } = new Size();                // Size object (Non-nullable)
}
