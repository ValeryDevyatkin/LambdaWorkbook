using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Domain.Model;
using LambdaWorkbook.Api.Persistence.Context;
using LambdaWorkbook.Api.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace LambdaWorkbook.Api.Persistence.Repository;

public class UserNoteRepository : RepositoryBase<UserNote>, IUserNoteRepository
{
    public UserNoteRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UserNote>> GetForUserAsync(int userId)
    {
        var notes = await Context.UserNotes
            .OrderByDescending(x => x.CreatedAt)
            .Where(x => x.UserId == userId)
            .ToListAsync();

        return notes;
    }
}