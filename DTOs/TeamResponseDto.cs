namespace UserAuth.Api.DTOs;

public class TeamResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public ICollection<DriverResponseDto> Drivers { get; set; }
}