using System;

namespace MBPhotography.Models;

public class PhotoPermission
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; }

    public bool CanUseOnWebsite { get; set; }
    public bool CanUseOnInstagram { get; set; }
    public bool CanUseOnFacebook { get; set; }
    public bool CanUseOnTikTok { get; set; }
    public bool CanUseOnPinterest { get; set; }
    public DateTime? ConsentDate { get; set; }
}
