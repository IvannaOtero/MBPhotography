using System.Collections.Generic;

namespace MBPhotography.Models;

public class SessionType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Appointment> Appointments { get; set; } = new();
}
