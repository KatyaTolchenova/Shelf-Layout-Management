using System;
using System.Collections.Generic;

public class Shelf
{
    public Guid Id { get; set; } = Guid.NewGuid();                       // Unique Row ID
    public List<Cabinet> Cabinets { get; set; } = new List<Cabinet>();   // List of Cabinets objects
}