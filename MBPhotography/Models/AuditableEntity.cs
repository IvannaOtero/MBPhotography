using System;

namespace MBPhotography.Models;

public abstract class AuditableEntity : IAuditable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
