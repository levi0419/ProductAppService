namespace ProductService.Infrastructure.Abstraction;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


public interface IProductServiceRepo<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}