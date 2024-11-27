using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Domain.Model;
using LambdaWorkbook.Api.Persistence.Context;
using LambdaWorkbook.Api.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace LambdaWorkbook.Api.Persistence.Repository;

public class UserMessageRepository : RepositoryBase<UserMessage, int>, IUserMessageRepository
{
    public UserMessageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<UserMessageItem>> GetAllAsync()
    {
        return await Context.UserMessages
            .AsNoTracking()
            .Include(x => x.User)
            .OrderBy(x => x.CreatedAt)
            .Select(x => new UserMessageItem
            {
                Id = x.Id,
                Text = x.Text,
                UserId = x.UserId,
                UserLogin = x.User!.Login
            })
            .ToListAsync();
    }
}