using LambdaWorkbook.Api.Application.Repository.Base;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Repository;

public interface IIdentityUserRepository : IRepository<IdentityUser>
{
    public Task<IdentityUser?> FindWhenLogInAsync(string? login, string? password);
    public Task<bool> FindLoginAsync(string? login);
}