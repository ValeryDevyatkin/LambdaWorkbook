namespace LambdaWorkbook.Api.Application.Repository;

public interface IUnitOfWork
{
    IIdentityUserRepository IdentityUserRepository { get; }

    public Task SaveChangesAsync();
}