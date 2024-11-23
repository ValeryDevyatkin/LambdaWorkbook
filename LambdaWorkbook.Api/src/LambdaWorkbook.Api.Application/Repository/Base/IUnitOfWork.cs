namespace LambdaWorkbook.Api.Application.Repository.Base;

public interface IUnitOfWork
{
    IIdentityUserRepository IdentityUserRepository { get; }
    IUserNoteRepository UserNoteRepository { get; }
    IUserMessageRepository UserMessageRepository { get; }

    public Task SaveChangesAsync();
}