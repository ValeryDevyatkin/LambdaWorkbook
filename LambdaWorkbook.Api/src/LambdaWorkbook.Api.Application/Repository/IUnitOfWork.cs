namespace LambdaWorkbook.Api.Application.Repository;

public interface IUnitOfWork
{
    ISystemUserRepository SystemUserRepository { get; }

    public Task SaveChangesAsync();
}