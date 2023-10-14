using Microsoft.EntityFrameworkCore;

namespace UserAuth.Api.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext>options):base(options){}
}