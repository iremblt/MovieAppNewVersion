using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Create(User t)
        {
            return await _userRepository.Create(t);
        }

        public async Task<string> Delete(int id)
        {
            return await _userRepository.Delete(id);
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public string IsMethodSuccess(int n)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> Save()
        {
            return await _userRepository.Save();
        }

        public async Task<string> Update(User t)
        {
            return await _userRepository.Update(t);
        }
    }
}
