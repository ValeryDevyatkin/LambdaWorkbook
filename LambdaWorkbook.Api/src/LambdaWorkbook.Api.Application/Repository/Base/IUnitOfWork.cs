namespace LambdaWorkbook.Api.Application.Repository.Base;

public interface IUnitOfWork
{
    IIdentityUserRepository IdentityUserRepository { get; }
    IUserNoteRepository UserNoteRepository { get; }

    public Task SaveChangesAsync();
}