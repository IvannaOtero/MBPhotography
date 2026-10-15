using System;
using System.Collections.Generic;

namespace MBPhotography.Models;

public class Package : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DurationMinutes { get; set; }
    public int EditedPhotoCount { get; set; }
    public decimal Price { get; set; }
    public bool Active { get; set; }

    public List<Appointment> Appointments { get; set; } = new();
}
