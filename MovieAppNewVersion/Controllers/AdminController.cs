using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieAppNewVersion.Data;
using MovieAppNewVersion.Entity;
using MovieAppNewVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieContext _movieContext;
        public AdminController(MovieContext movieContext)
        {
            _movieContext =movieContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MovieList()
        {
            var movies = _movieContext.Movies.AsQueryable();
            var model = new AdminMoviesViewModel()
            {
                Movies = movies
                .Include(m => m.Categories)
                .Select(i => new AdminMovieModel()
                {
                    MovieId = i.MovieId,
                    MovieImage = i.MovieImage,
                    MovieTitle = i.MovieTitle,
                    Categories=i.Categories.Select(c=>new CategoryMovieModel()
                    {
                        Name=c.Name
                    }).ToList()
                })
                .ToList()
            };
            return View(model);
        }
        public IActionResult CategoryList()
        {

            return View( new AdminCategoriesViewModel
            {
                Categories=_movieContext.Categories.Select(g=> new AdminCategoryViewModel
                {
                    CategoryId=g.CategoryId,
                    CategoryName=g.Name,
                    Count=g.Movies.Count
                }).ToList()
            });
        }
        [HttpGet]
        public IActionResult Update(int ? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _movieContext.Movies.Select(m => new UpdateMovieModel
            {
                MovieId = m.MovieId,
                MovieTitle = m.MovieTitle,
                Description = m.MovieDescription,
                About = m.MovieAbout,
                MovieImage = m.MovieImage,
                SelectedCategories=m.Categories
            }).FirstOrDefault(m=>m.MovieId==id);
            ViewBag.Categories = _movieContext.Categories.ToList();
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost]
        public IActionResult Update(UpdateMovieModel model, int [] categoryId)
        {
            var enitity = _movieContext.Movies.Include("Categories").FirstOrDefault(m=>m.MovieId==model.MovieId);
            if (enitity == null)
            {
                return NotFound();
            }
            enitity.MovieTitle = model.MovieTitle;
            enitity.MovieDescription = model.Description;
            enitity.MovieAbout = model.About;
            enitity.MovieImage = model.MovieImage;
            enitity.Categories = categoryId.Select(
                id => _movieContext.Categories.FirstOrDefault(i => i.CategoryId == id)).ToList();
            _movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int ? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = _movieContext.Movies.Select(m => new DeleteMovieModel
            {
                MovieId = m.MovieId
            }).FirstOrDefault(i => i.MovieId == id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(DeleteMovieModel model)
        {
            var entity = _movieContext.Movies.Find(model.MovieId);
            if (entity == null)
            {
                return NotFound();
            }
            _movieContext.Movies.Remove(entity);
            _movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Movie model,int [] categoryId)
        {
            if (ModelState.IsValid)
            {
                model.Categories = new List<Category>();
                foreach (var id in categoryId)
                {
                    model.Categories.Add(_movieContext.Categories.FirstOrDefault(i => i.CategoryId == id));
                }
                _movieContext.Movies.Add(model);
                _movieContext.SaveChanges();
                return RedirectToAction("MovieList","Admin");
            }
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View();
        }
        [HttpGet]
        public IActionResult CategoryUpdate(int ?id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _movieContext
                .Categories.Select(c=> new UpdateCategoryViewModel { 
                    CategoryId=c.CategoryId,
                    CategoryName=c.Name,
                    AdminMovieModels=c.Movies.Select(i=> new AdminMovieModel
                    {
                         MovieId=i.MovieId,
                         MovieTitle=i.MovieTitle,
                         MovieImage=i.MovieImage
                    }).ToList()
                }).ToList()
                .FirstOrDefault(i => i.CategoryId == id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(UpdateCategoryViewModel model,int [] movieIds)
        {
            var entity = _movieContext.Categories
                .Include("Movies")
                .FirstOrDefault(i => i.CategoryId == model.CategoryId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.CategoryName;
            foreach (var id in movieIds)
            {
                entity.Movies.Remove(entity.Movies.FirstOrDefault(m => m.MovieId==id));
            }
            _movieContext.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult CategoryDelete(int ? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _movieContext.Categories.Select(i => new DeleteCategoryModel
            {
                CategoryId = i.CategoryId
            }).FirstOrDefault(a=> a.CategoryId==id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult CategoryDelete(DeleteCategoryModel model)
        {
            var entity = _movieContext.Categories.Find(model.CategoryId);
            if (entity == null)
            {
                return NotFound();
            }
            _movieContext.Categories.Remove(entity);
            _movieContext.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}
