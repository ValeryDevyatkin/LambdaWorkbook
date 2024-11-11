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

    public async Task<IdentityUser> FindWhenLogInAsync(string? login, string? password)
    {
        var user = await Context.IdentityUsers.SingleAsync(x => x.Login == login && x.Password == password);

        return user;
    }
}