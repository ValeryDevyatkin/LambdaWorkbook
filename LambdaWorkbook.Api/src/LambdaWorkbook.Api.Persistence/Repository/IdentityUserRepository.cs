using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Domain.Model;
using LambdaWorkbook.Api.Persistence.Context;
using LambdaWorkbook.Api.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace LambdaWorkbook.Api.Persistence.Repository;

public class IdentityUserRepository : RepositoryBase<IdentityUser>, IIdentityUserRepository
{
    public IdentityUserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IdentityUser?> FindWhenLogInAsync(string? login, string? password)
    {
        var user = await Context.IdentityUsers
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Login == login && x.Password == password);

        return user;
    }

    public async Task<bool> FindLoginAsync(string? login)
    {
        var exists = await Context.IdentityUsers.AnyAsync(x => x.Login == login);

        return exists;
    }
}