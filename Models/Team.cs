namespace UserAuth.Api.Models;

public class Team: BaseEntity
{
    public Team()
    {
        Drivers = new HashSet<Driver>();
    }
    public string Name { get; set; } = "";
    public int Year { get; set; } = 2022;
    public virtual ICollection<Driver>Drivers { get; set; }
}