using System;
using System.Collections.Generic;

namespace MBPhotography.Models;

public class Customer : AuditableEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public List<Appointment> Appointments { get; set; } = new();
    public List<Review> Reviews { get; set; } = new();
}
