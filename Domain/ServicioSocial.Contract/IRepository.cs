using System.Linq.Expressions;

namespace ServicioSocial.Contract
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> SingleAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);
    }
}