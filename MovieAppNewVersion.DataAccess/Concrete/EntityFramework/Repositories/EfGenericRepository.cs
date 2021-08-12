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
             _movieAppContext.Set<T>().Add(t);
            return await Save();
        }
        public async Task<string>Delete(int id)
        {
            var find = GetById(id);
            if (id != 0)
            {
                 _movieAppContext.Set<T>().Remove(find);
                return await Save();
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

        public async Task<string> Save()
        {
            var result=await _movieAppContext.SaveChangesAsync();
            if (result > 0)
            {
                return "The process succesfully to completed";
            }
            else
            {
                return "The process failed";
            }
        }
        public async Task<string> Update(T t)
        {
             _movieAppContext.Set<T>().Update(t);
            return await Save();
        } 
    }
}
