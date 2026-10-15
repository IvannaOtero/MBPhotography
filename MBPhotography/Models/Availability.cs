using System;

namespace MBPhotography.Models;

public class Availability : AuditableEntity
{
    public int Id { get; set; }
    public DateTime AvailableDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool IsAvailable { get; set; }
}
