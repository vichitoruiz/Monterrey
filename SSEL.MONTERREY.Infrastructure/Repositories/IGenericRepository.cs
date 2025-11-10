using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SSEL.MONTERREY.Infrastructure.Repositories;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> Query();
    Task<T?> GetByIdAsync(object id);
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
