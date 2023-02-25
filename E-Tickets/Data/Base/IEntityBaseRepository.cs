using E_Tickets.Models;
using System.Linq.Expressions;

namespace E_Tickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetById(int id);
        Task<T> GetById(int id, params Expression<Func<T, object>>[] includeProperties);

        Task Add(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);

    }
}
