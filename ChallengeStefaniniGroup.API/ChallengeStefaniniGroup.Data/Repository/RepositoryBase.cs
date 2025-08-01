using ChallengeStefaniniGroup.Data.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
namespace ChallengeStefaniniGroup.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DataContext _context;
        public RepositoryBase(DataContext context) => _context = context;
        public async Task<T?> GetById(ObjectId id) =>
            await _context.Set<T>().FindAsync(id);
        public async Task<List<T>> GetAll() =>
            await _context.Set<T>().ToListAsync();
        public async Task<bool> Add(T newObject)
        {
            try
            {
                await _context.Set<T>().AddAsync(newObject);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<(bool, string)> Update(T objectDomain)
        {
            try
            {
                _context.Set<T>().Update(objectDomain);
                await _context.SaveChangesAsync();
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public async Task<(bool, string)> Delete(ObjectId id)
        {
            try
            {
                var objectDomain = await GetById(id);
                if (objectDomain == null)
                    return (false, "Objeto não encontrado");
                _context.Set<T>().Remove(objectDomain);
                await _context.SaveChangesAsync();
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
