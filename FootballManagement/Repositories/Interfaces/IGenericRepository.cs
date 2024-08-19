using FootballManagement.Models;

namespace FootballManagement.Repositories.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    Task AddRangeAsync(ICollection<T> entities);
    bool Update(T entity);
    Task<bool> Remove(int id);
    bool Remove(T entity);
    IQueryable<T> GetAll();
    Task<T> Get(int id);
    int Save();
    Task<int> SaveAsync();
}