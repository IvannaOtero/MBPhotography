using System;

namespace MBPhotography.Models;

public class AppointmentReminder
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; }
    public string ReminderType { get; set; }
    public DateTime ScheduledFor { get; set; }
    public bool Sent { get; set; }
    public DateTime? SentAt { get; set; }
}
