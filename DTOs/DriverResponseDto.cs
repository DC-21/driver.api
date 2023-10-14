namespace UserAuth.Api.DTOs;

public class DriverResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RacingNumber { get; set; }
    public TeamResponseDto Team { get; set; }
    public DriverMediaResponseDto DriverMedia { get; set; }
}