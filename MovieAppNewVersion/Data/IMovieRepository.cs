using MovieAppNewVersion.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Data
{
    public interface IMovieRepository
    {
        Movie GetById(int id);
        IQueryable<Movie> GetAll();
        Movie AddMovie(Movie movie);
        void DeleteMovie(int id);
        Movie PutMovie(Movie movie);
    }
}
