using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        Task<T> Add(T t);
        Task<T> Delete(int id);
        Task<T> Update(T t);
        void Save();
    }
}
