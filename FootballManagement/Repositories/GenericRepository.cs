using FootballManagement.AppDbContext;
using FootballManagement.Models;
using FootballManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballManagement.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly Context _context;
    private readonly DbSet<T> _dbSet;


    public GenericRepository()
    {
        _context = new Context();
        _dbSet = _context.Set<T>();
    }

    public async Task<bool> AddAsync(T entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);
        return entityEntry.State == EntityState.Added;
    }

    public async Task AddRangeAsync(ICollection<T> entities)
        => await _dbSet.AddRangeAsync(entities);

    public bool Update(T entity)
    {
        var entityEntry = _dbSet.Update(entity);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<bool> Remove(int id)
    {
        var entity = await Get(id);
        var entityEntry = _dbSet.Remove(entity);
        return entityEntry.State == EntityState.Modified;
    }

    public bool Remove(T entity)
    {
        var entityEntry = _dbSet.Remove(entity);
        return entityEntry.State == EntityState.Deleted;
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public async Task<T> Get(int id)
    {
        var entity = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (entity is null)
            throw new Exception("Entity is not found");

        return entity;
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}