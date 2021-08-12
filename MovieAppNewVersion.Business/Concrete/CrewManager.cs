using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Concrete
{
    public class CrewManager : ICrewService
    {
        private readonly ICrewRepository _crewRepository;
        public CrewManager(ICrewRepository crewRepository)
        {
            _crewRepository = crewRepository;
        }
        public async Task<string> Create(Crew t)
        {
            return await _crewRepository.Create(t);
        }

        public async Task<string> Delete(int id)
        {
            return await _crewRepository.Delete(id);
        }

        public IQueryable<Crew> GetAll()
        {
            return _crewRepository.GetAll();
        }

        public Crew GetById(int id)
        {
            return _crewRepository.GetById(id);
        }

        public async Task<string> Save()
        {
            return await _crewRepository.Save();
        }

        public async Task<string> Update(Crew t)
        {
            return await _crewRepository.Update(t);
        }
    }
}
