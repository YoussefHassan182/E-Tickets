using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace E_Tickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext context;
        public EntityBaseRepository(AppDbContext _context)
        {
           context = _context;
        }
        public async Task Add(T entity)
        {
             context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll() => await context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<T> GetById(int id) => await context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);

        public async Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task Update(int id, T entity)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await context.SaveChangesAsync();
        }
    }
}
