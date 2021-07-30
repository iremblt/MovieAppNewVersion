using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T: class
    {
        protected readonly MovieContext _movieAppContext;
        public EfGenericRepository(MovieContext movieAppContext)
        {
            _movieAppContext = movieAppContext;
        }
        public async Task<T> Add(T t)
        {
            var added = await _movieAppContext.Set<T>().AddAsync(t);
            await _movieAppContext.SaveChangesAsync();
            return added.Entity;

        }

        public async Task<T> Delete(int id)
        {
            var find = GetById(id);
            if (id != 0)
            {
                var remove = _movieAppContext.Set<T>().Remove(find);
                await _movieAppContext.SaveChangesAsync();
                return remove.Entity;
            }
            return null;
        }
        public IQueryable<T> GetAll()
        {
            return _movieAppContext.Set<T>().AsQueryable();
        }

        public T GetById(int id)
        {
            return _movieAppContext.Set<T>().Find(id);
        }

        public void Save()
        {
            _movieAppContext.SaveChanges();
        }

        public async Task<T> Update(T t)
        {
            var updated = _movieAppContext.Set<T>().Update(t);
            await _movieAppContext.SaveChangesAsync();
            return updated.Entity;
        }
    }
}
