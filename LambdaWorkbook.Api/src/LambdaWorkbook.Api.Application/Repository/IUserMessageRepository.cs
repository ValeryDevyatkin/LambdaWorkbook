using LambdaWorkbook.Api.Application.Repository.Base;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Repository;

public interface IUserMessageRepository : IRepository<UserMessage>
{
    Task<IEnumerable<UserMessageItem>> GetAllAsync();
}