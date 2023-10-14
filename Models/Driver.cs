namespace UserAuth.Api.Models;

public class Driver: BaseEntity
{
    public int TeamId { get; set; }
    public string Name { get; set; } = "";
    public int RacingNumber { get; set; }
    public virtual Team Team { get; set; }
    public virtual DriverMedia DriverMedia { get; set; }
}