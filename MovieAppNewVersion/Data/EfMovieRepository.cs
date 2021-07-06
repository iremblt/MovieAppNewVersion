using MovieAppNewVersion.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Data
{
    public class EfMovieRepository : IMovieRepository
    {
        private MovieContext _movieContext;
        public EfMovieRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public Movie GetById (int id)
        {
            return _movieContext.Movies.Find(id);   
        }

        public Movie AddMovie(Movie movie)
        {
            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
            return movie;
        }

        public void DeleteMovie(int id)
        {
            var movie= _movieContext.Movies.FirstOrDefault(i=>i.MovieId==id);
            if (movie != null)
            {
                _movieContext.Movies.Remove(movie);
                _movieContext.SaveChanges();
            }
        }

        public IQueryable<Movie> GetAll()
        {
            return _movieContext.Movies.AsQueryable();
        }

        public Movie PutMovie(Movie movie)
        {
            _movieContext.Movies.Update(movie);
            _movieContext.SaveChanges();
            return movie;
        }
    }
}
