using System;

namespace MBPhotography.Models;

public class Review
{
    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int? AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; }
    public bool Approved { get; set; }
    public DateTime CreatedAt { get; set; }
}
