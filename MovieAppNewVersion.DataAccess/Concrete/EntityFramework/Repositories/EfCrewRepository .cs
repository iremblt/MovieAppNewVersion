using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfCrewRepository:EfGenericRepository<Crew>,ICrewRepository
    {
        public EfCrewRepository(MovieContext context) : base(context)
        {

        }
    }
}
