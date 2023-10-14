namespace UserAuth.Api.DTOs;

public class DriverRequestDto
{
    public int TeamId { get; set; }
    public string Name { get; set; }
    public int RacingNumber { get; set; }
    public TeamRequestDto Team { get; set; }
    public DriverMediaRequestDto DriverMedia { get; set; }
}