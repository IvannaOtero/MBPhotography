using System.Collections.Generic;

namespace MBPhotography.Models;

public class GalleryCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<GalleryImage> Images { get; set; } = new();
}
