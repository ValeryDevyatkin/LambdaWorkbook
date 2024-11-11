using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Persistence.Context;

namespace LambdaWorkbook.Api.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(
        AppDbContext context,
        IIdentityUserRepository identityUserRepository)
    {
        _context = context;

        IdentityUserRepository = identityUserRepository;
    }

    public IIdentityUserRepository IdentityUserRepository { get; }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}