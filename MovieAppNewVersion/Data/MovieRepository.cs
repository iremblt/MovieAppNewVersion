using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.Entity;
using MovieAppNewVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Data
{
    public class MovieRepository : IMovieRepository
    {
        private MovieContext _movieContext;
        public MovieRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task<Movie> GetById (int id)
        {
            var find = await _movieContext.Movies
                .Include(i => i.Categories)
                .FirstOrDefaultAsync(i => i.MovieId == id);
            return find;
        }

        public async Task<Movie> AddMovie(AddMovie movie)
        {
            var added = await _movieContext.Movies.AddAsync(new Movie
            {
                MovieAbout = movie.MovieAbout,
                MovieDescription = movie.MovieDescription,
                MovieImage = movie.MovieImage,
                MovieTitle = movie.MovieTitle,
                Categories=movie.Categories,
            });
            await SaveChangeMethodAsync();
            movie.MovieId = _movieContext.Movies.Max(i => i.MovieId);
            return added.Entity;
        }
        public async Task<Movie> DeleteMovie(int id)
        {
            var deleted = await GetById(id);
            if (deleted != null)
            {
                _movieContext.Movies.Remove(deleted);
                await SaveChangeMethodAsync();
                return deleted;
            }
            return null;
        }

        private async Task SaveChangeMethodAsync()
        {
            await _movieContext.SaveChangesAsync();
        }

        public IQueryable<Movie> GetAll()
        {
            return _movieContext.Movies.AsQueryable();
        }

        public async Task<Movie> EditMovie(UpdateMovie updateMovie)
        {
            var updatedModel = await GetById(updateMovie.MovieId);
            if (updatedModel != null)
            {
                updatedModel.MovieAbout = updateMovie.MovieAbout;
                updatedModel.MovieDescription = updateMovie.MovieDescription;
                updatedModel.MovieImage = updateMovie.MovieImage;
                updatedModel.MovieTitle = updateMovie.MovieTitle;
                updatedModel.Categories = updateMovie.Categories;
                await SaveChangeMethodAsync();
                return updatedModel;
            }
            return null;
        }
        public async Task<Movie> UpdateMovie(UpdateMovie updateMovie)
        {
            var updatedModel = await GetById(updateMovie.MovieId);

            if (updatedModel != null)
            {
                updatedModel.MovieAbout = updateMovie.MovieAbout;
                updatedModel.MovieDescription = updateMovie.MovieDescription;
                updatedModel.MovieImage = updateMovie.MovieImage;
                updatedModel.MovieTitle = updateMovie.MovieTitle;
                updatedModel.Categories = updateMovie.Categories;
                await SaveChangeMethodAsync();
                return updatedModel;
            }
            return null;
        }
        public void Save()
        {
            _movieContext.SaveChanges();
        }
    }
}
