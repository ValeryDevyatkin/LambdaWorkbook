using LambdaWorkbook.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace LambdaWorkbook.Api.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<IdentityUser> IdentityUsers { get; set; }
    public DbSet<IdentityRole> IdentityRoles { get; set; }
    public DbSet<UserNote> UserNotes { get; set; }
}