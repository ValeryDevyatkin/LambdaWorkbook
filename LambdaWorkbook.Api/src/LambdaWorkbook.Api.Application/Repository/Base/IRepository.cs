using LambdaWorkbook.Api.Domain.Model.Base;

namespace LambdaWorkbook.Api.Application.Repository.Base;

public interface IRepository<T> where T : ModelBase
{
    Task<IEnumerable<T>> GetAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> CreateAsync(T item);
    Task UpdateAsync(T item);
    Task<bool> DeleteAsync(int id);
}