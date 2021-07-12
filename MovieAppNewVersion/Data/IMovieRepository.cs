using MovieAppNewVersion.Entity;
using MovieAppNewVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Data
{
    public interface IMovieRepository
    {
        Task<Movie> GetById(int id);
        IQueryable<Movie> GetAll();
        Task<Movie> AddMovie(AddMovie movie);
        Task<Movie> DeleteMovie(int id);
        Task<Movie> EditMovie(UpdateMovie movie);
        Task<Movie> UpdateMovie(UpdateMovie updateMovie);
        void Save();
    }
}
