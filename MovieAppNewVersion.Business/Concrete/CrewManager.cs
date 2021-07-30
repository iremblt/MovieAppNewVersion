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
        public async Task<Crew> Add(Crew t)
        {
            return await _crewRepository.Add(t);
        }

        public async Task<Crew> Delete(int id)
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

        public void Save()
        {
            _crewRepository.Save();
        }

        public async Task<Crew> Update(Crew t)
        {
            return await _crewRepository.Update(t);
        }
    }
}
