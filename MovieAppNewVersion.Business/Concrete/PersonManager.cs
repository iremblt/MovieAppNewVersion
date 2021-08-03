using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonManager(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<string> Create(Person t)
        {
            return await _personRepository.Create(t);
        }

        public async Task<string> Delete(int id)
        {
            return await _personRepository.Delete(id);
        }

        public IQueryable<Person> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Person GetById(int ?id)
        {
            return _personRepository.GetById(id);
        }

        public string IsMethodSuccess(int n)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _personRepository.Save();
        }

        public async Task<string> Update(Person t)
        {
            return await _personRepository.Update(t);
        }
    }
}
