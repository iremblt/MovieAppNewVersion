using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.Entities.Concrete;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Business.Concrete
{
    public class VoteManager : IVoteService
    {
        private readonly IVoteRepoistory _voteRepository;
        public VoteManager(IVoteRepoistory voteRepoistory)
        {
            _voteRepository = voteRepoistory;
        }
        public async Task<string> Create(Vote t)
        {
            return await _voteRepository.Create(t);
        }

        public async Task<string> Delete(int id)
        {
            return await _voteRepository.Delete(id);
        }

        public IQueryable<Vote> GetAll()
        {
            return _voteRepository.GetAll();
        }

        public Vote GetById(int ? id)
        {
            return _voteRepository.GetById(id);
        }

        public string IsMethodSuccess(int n)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _voteRepository.Save();
        }

        public async Task<string> Update(Vote t)
        {
            return await _voteRepository.Update(t);
        }
    }
}
