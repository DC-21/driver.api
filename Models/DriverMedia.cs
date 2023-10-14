namespace UserAuth.Api.Models;

public class DriverMedia : BaseEntity
{
    public int DriverId { get; set; }
    public string Media { get; set; } = "";
    public virtual Driver Driver { get; set; }
}