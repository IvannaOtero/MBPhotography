using System;

namespace MBPhotography.Models;

public class Message
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Subject { get; set; }
    public string MessageText { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}
