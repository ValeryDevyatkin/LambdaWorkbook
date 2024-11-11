using LambdaWorkbook.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace LambdaWorkbook.Api.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<IdentityUser> IdntityUsers { get; set; }
    public DbSet<IdentityRole> IdntityRoles { get; set; }
}