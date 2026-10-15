using System;
using System.Collections.Generic;
using MBPhotography.Enums;

namespace MBPhotography.Models;

public class Appointment : AuditableEntity
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int? SessionTypeId { get; set; }
    public SessionType SessionType { get; set; }

    public int? PackageId { get; set; }
    public Package Package { get; set; }

    public DateTime AppointmentDate { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string PhotoshootLocation { get; set; }
    public int ParticipantCount { get; set; }
    public string SpecialRequests { get; set; }
    public AppointmentStatus Status { get; set; }

    public List<Payment> Payments { get; set; } = new();
    public PhotoPermission PhotoPermission { get; set; }
    public List<AppointmentReminder> Reminders { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}
