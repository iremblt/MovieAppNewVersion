using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCastRepository:EfGenericRepository<Cast>,ICastRepository
    {
        public EfCastRepository(MovieContext context) : base(context)
        {

        }
    }
}
