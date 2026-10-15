using System;

namespace MBPhotography.Models;

public class GalleryImage : AuditableEntity
{
    public int Id { get; set; }
    public int? CategoryId { get; set; }
    public GalleryCategory Category { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool Featured { get; set; }
}
