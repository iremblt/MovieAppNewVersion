using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Abstract
{
    public interface IGenericService<T> where T:class
    {
        IQueryable<T> GetAll();
        Task<T> Add(T t);
        Task<T> Delete(int id);
        Task<T> Update(T t);
        T GetById(int id);
        void Save();
    }
}
