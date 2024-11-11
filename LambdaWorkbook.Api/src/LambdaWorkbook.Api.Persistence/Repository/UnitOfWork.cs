using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Persistence.Context;

namespace LambdaWorkbook.Api.Persistence.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(
        AppDbContext context,
        ISystemUserRepository systemUserRepository)
    {
        _context = context;

        SystemUserRepository = systemUserRepository;
    }

    public ISystemUserRepository SystemUserRepository { get; }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}