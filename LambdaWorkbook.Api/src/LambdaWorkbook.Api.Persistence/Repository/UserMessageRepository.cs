using LambdaWorkbook.Api.Application.Repository;
using LambdaWorkbook.Api.Domain.Model;
using LambdaWorkbook.Api.Persistence.Context;
using LambdaWorkbook.Api.Persistence.Repository.Base;

namespace LambdaWorkbook.Api.Persistence.Repository;

public class UserMessageRepository : RepositoryBase<UserMessage>, IUserMessageRepository
{
    public UserMessageRepository(AppDbContext context) : base(context)
    {
    }
}