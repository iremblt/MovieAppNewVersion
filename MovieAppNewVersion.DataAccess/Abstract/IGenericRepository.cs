using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        Task<string> Create(T t);
        Task<string> Delete(int id);
        Task<string> Update(T t);
        Task<string> Save();
    }
}
