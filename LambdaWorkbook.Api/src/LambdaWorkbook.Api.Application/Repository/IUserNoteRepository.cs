using LambdaWorkbook.Api.Application.Repository.Base;
using LambdaWorkbook.Api.Domain.Model;

namespace LambdaWorkbook.Api.Application.Repository;

public interface IUserNoteRepository : IRepository<UserNote>
{
    public Task<IEnumerable<UserNote>> GetForUserAsync(int userId);
}