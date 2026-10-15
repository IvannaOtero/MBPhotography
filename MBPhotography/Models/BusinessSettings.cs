using System;

namespace MBPhotography.Models;

public class BusinessSettings
{
    public int Id { get; set; }
    public string BusinessName { get; set; }
    public string BusinessEmail { get; set; }
    public string BusinessPhone { get; set; }
    public string InstagramUrl { get; set; }
    public string FacebookUrl { get; set; }
    public string TikTokUrl { get; set; }
    public string PinterestUrl { get; set; }
    public decimal DepositPercentage { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
