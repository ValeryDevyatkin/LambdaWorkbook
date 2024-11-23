using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Application.Repository.Base;
using LambdaWorkbook.Api.Persistence.Context;

namespace LambdaWorkbook.Api.Persistence.Repository.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(
        AppDbContext context,
        IIdentityUserRepository identityUserRepository,
        IUserNoteRepository userNoteRepository,
        IUserMessageRepository userMessageRepository)
    {
        _context = context;

        IdentityUserRepository = identityUserRepository;
        UserNoteRepository = userNoteRepository;
        UserMessageRepository = userMessageRepository;
    }

    public IIdentityUserRepository IdentityUserRepository { get; }
    public IUserNoteRepository UserNoteRepository { get; }
    public IUserMessageRepository UserMessageRepository { get; }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}