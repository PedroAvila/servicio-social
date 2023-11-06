using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ServicioSocial.Contract;

namespace ServicioSocial.Repository
{
    public class BaseRespository<T> : IRepository<T> where T : class
    {
        private readonly ServicioSocialContext _context;

        public BaseRespository(ServicioSocialContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await SingleAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate)
        {
            bool exist = await _context.Set<T>().AnyAsync(predicate);
            return exist;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> SingleAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}