using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfVoteRepository:EfGenericRepository<Vote>,IVoteRepoistory
    {
        public EfVoteRepository(MovieContext context) : base(context)
        {

        }
    }
}
