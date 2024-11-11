using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Domain.Model;
using LambdaWorkbook.Api.Persistence.Context;
using LambdaWorkbook.Api.Persistence.Repository.Base;

namespace LambdaWorkbook.Api.Persistence.Repository;

public class IdentityUserRepository : RepositoryBase<IdentityUser>, IIdentityUserRepository
{
    public IdentityUserRepository(AppDbContext context) : base(context)
    {
    }
}