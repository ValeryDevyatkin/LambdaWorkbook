using LambdaWorkbook.Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace LambdaWorkbook.Api.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<IdentityUserModel> IdntityUsers { get; set; }
}