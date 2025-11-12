using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SSEL.MONTERREY.Domain.Repositories;

namespace SSEL.MONTERREY.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _ctx;
    public GenericRepository(DbContext ctx) => _ctx = ctx;

    public IQueryable<T> Query() => _ctx.Set<T>().AsQueryable();

    public async Task<T?> GetByIdAsync(object id) => await _ctx.Set<T>().FindAsync(id);

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null)
        => predicate is null
            ? await _ctx.Set<T>().ToListAsync()
            : await _ctx.Set<T>().Where(predicate).ToListAsync();

    public async Task<T> AddAsync(T entity)
    {
        await _ctx.Set<T>().AddAsync(entity);
        await _ctx.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _ctx.Set<T>().Update(entity);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _ctx.Set<T>().Remove(entity);
        await _ctx.SaveChangesAsync();
    }
}
