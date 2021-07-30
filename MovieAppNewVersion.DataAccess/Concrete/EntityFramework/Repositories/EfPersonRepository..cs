using MovieAppNewVersion.DataAccess.Abstract;
using MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Contexts;
using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfPersonRepository:EfGenericRepository<Person>,IPersonRepository
    {
        public EfPersonRepository(MovieContext context) : base(context)
        {

        }
    }
}
