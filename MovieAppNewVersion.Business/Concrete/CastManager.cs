using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Concrete
{
    public class CastManager : ICastService
    {
        private readonly ICastRepository _castRepository;
        public CastManager(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }
        public async Task<string> Create(Cast t)
        {
            return await _castRepository.Create(t);
        }

        public async Task<string>  Delete(int id)
        {
            return await _castRepository.Delete(id);
        }

        public IQueryable<Cast> GetAll()
        {
            return _castRepository.GetAll();
        }

        public Cast GetById(int id)
        {
            return _castRepository.GetById(id);
        }

        public async Task<string> Save()
        {
            return await _castRepository.Save();
        }
        public Task<string> Update(Cast t)
        {
            return _castRepository.Update(t);
        }
    }
}
