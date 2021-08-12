using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<string> Create(T t);
        Task<string> Delete(int id);
        Task<string> Update(T t);
        T GetById(int id);
        Task<string> Save();
    }
}
