using Microsoft.AspNetCore.Mvc;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DTO.DTOs.CategoryDTO;
using MovieAppNewVersion.Entities.Concrete;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult CategoryList()
        {
            var categories = _categoryService.GetAllCategoriesIncludeMovies();
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryAdd(CategoryAddDTO categoryAdd)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategory(categoryAdd);
                return RedirectToAction("CategoryList");
            }
            return View(categoryAdd);

        }
        [HttpGet]
        public ActionResult<Category> CategoryUpdate(int id)
        {
            var result = _categoryService.GetByCategoryId(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(CategoryUpdateDTO updateCategory)
        {
            if (ModelState.IsValid) 
            {
                await _categoryService.UpdateCategory(updateCategory);
                return RedirectToAction("CategoryList");
            }
            return View(updateCategory);

        }
        [HttpGet]
        public IActionResult CategoryDeleteConfirmed(int id)
        {
            var result =_categoryService.GetByCategoryId(id);
            if (result != null)
            {
                return View(result);
            }
            return NotFound();
        }
        [HttpPost, ActionName("CategoryDeleteConfirmed")]
        public async Task<IActionResult> CategoryDelete(CategoryDeleteDTO category)
        {
            await _categoryService.DeleteCategory(category.CategoryId);
            return RedirectToAction("CategoryList");
        }
    }
}
