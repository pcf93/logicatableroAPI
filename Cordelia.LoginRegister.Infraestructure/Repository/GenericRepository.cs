using Cordelia.LoginRegister.Application.Repository;
using Cordelia.LoginRegister.Domain.Model;
using Cordelia.LoginRegister.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cordelia.LoginRegister.Infraestructure.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly ApplicationContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public DbSet<TEntity> GetEntityContext() { 
        return _dbSet;
    }

    public async Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter = null)
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();

    }

    public async Task<TEntity?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);

    }

    public virtual void Update(TEntity entityToUpdate)
    {
        _dbSet.Attach(entityToUpdate);
        _dbContext.Entry(entityToUpdate).State = EntityState.Modified;

    }
    
    public async Task Delete(object id)
    {
        TEntity entityToDelete = await _dbSet.FindAsync(id);
        _dbSet.Remove(entityToDelete);

        await Task.CompletedTask;
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (_dbContext.Entry(entityToDelete).State == EntityState.Detached) {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);
    }
}
