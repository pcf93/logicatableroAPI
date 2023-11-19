using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cordelia.LoginRegister.Application.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        
        public DbSet<TEntity> GetEntityContext();

        public Task<IEnumerable<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter = null);

        public Task<TEntity?> GetByIdAsync(object id);

        public Task InsertAsync(TEntity entity);

        public void Update(TEntity entityToUpdate);

        public Task Delete(object id);

        public void Delete(TEntity entityToDelete);
    }
}
