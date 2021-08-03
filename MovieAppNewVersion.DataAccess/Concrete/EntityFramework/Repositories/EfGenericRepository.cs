using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MovieContext _movieAppContext;
        public EfGenericRepository(MovieContext movieAppContext)
        {
            _movieAppContext = movieAppContext;
        }
        public async Task<string> Create(T t)
        {
            var added = _movieAppContext.Set<T>().Add(t);
            var IsSuccess = await _movieAppContext.SaveChangesAsync();
            return IsMethodSuccess(IsSuccess);
        }
        public async Task<string>Delete(int id)
        {
            var find = GetById(id);
            if (id != 0)
            {
                var remove = _movieAppContext.Set<T>().Remove(find);
                var IsSuccess= await _movieAppContext.SaveChangesAsync();
                return IsMethodSuccess(IsSuccess);
            }
            return null;
        }
        public IQueryable<T> GetAll()
        {
            return _movieAppContext.Set<T>().AsQueryable();
        }

        public T GetById(int ?id)
        {
            return _movieAppContext.Set<T>().Find(id);
        }

        public void Save()
        {
            _movieAppContext.SaveChanges();
        }
        public async Task<string> Update(T t)
        {
            var updated = _movieAppContext.Set<T>().Update(t);
            var IsSuccess = await _movieAppContext.SaveChangesAsync();
            return IsMethodSuccess(IsSuccess);
        } 
        public string IsMethodSuccess(int n) 
        {
            if (n > 0)
            {
                return "The process succesfully to completed";
            }
            else
            {
                return "The process failed";
            }
        }
    }
}
