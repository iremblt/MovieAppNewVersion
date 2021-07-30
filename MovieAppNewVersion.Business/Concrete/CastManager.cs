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
        public async Task<Cast> Add(Cast t)
        {
            return await _castRepository.Add(t);
        }

        public async Task<Cast> Delete(int id)
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

        public void Save()
        {
            _castRepository.Save();
        }

        public async Task<Cast> Update(Cast t)
        {
            return await _castRepository.Update(t);
        }
    }
}
