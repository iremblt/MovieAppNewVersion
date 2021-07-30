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
        public async Task<Vote> Add(Vote t)
        {
            return await _voteRepository.Add(t);
        }

        public async Task<Vote> Delete(int id)
        {
            return await _voteRepository.Delete(id);
        }

        public IQueryable<Vote> GetAll()
        {
            return _voteRepository.GetAll();
        }

        public Vote GetById(int id)
        {
            return _voteRepository.GetById(id);
        }

        public void Save()
        {
            _voteRepository.Save();
        }

        public async Task<Vote> Update(Vote t)
        {
            return await _voteRepository.Update(t);
        }
    }
}
