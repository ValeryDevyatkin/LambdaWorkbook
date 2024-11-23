using LambdaWorkbook.Api.Domain.Model;
using LambdaWorkbook.Api.Domain.Model.Base;
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
    public DbSet<UserMessage> UserMessages { get; set; }

    public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is ModelBase &&
                (e.State == EntityState.Added || e.State == EntityState.Modified));

        var updateTime = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            var trackableEntity = (ModelBase)entry.Entity;

            if (entry.State == EntityState.Added)
            {
                trackableEntity.CreatedAt = updateTime;
            }

            trackableEntity.ModifiedAt = updateTime;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}