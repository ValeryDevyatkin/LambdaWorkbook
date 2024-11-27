using LambdaWorkbook.Api.Application.Repository.Base;
using LambdaWorkbook.Api.Domain.Model.Base;
using LambdaWorkbook.Api.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace LambdaWorkbook.Api.Persistence.Repository.Base;

public abstract class RepositoryBase<T, TKey> : IRepository<T>
    where T : ModelBase<TKey>
    where TKey: struct
{
    protected AppDbContext Context { get; }

    public RepositoryBase(AppDbContext context)
    {
        Context = context;
    }

    public async Task<T> CreateAsync(T item)
    {
        var createdItem = await Context.Set<T>().AddAsync(item);
        await Context.SaveChangesAsync();

        return createdItem.Entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var item = await Context.Set<T>().FindAsync(id);

        if (item == null)
        {
            return false;
        }

        Context.Set<T>().Remove(item);
        await Context.SaveChangesAsync();

        return true;
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task UpdateAsync(T item)
    {
        var dbItem = await Context.Set<T>()
            .AsNoTracking()
            .SingleAsync(x => x.Id.Equals(item.Id));

        item.CreatedAt = dbItem?.CreatedAt ?? DateTime.MinValue;

        Context.Entry(item).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }
}