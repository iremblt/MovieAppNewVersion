using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfUserRepository:EfGenericRepository<User>,IUserRepository
    {
        public EfUserRepository(MovieContext context) : base(context)
        {

        }
    }
}
