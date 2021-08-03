using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAppNewVersion.Business.Abstract;
using MovieAppNewVersion.DTO.DTOs.CategoryDTO;
using MovieAppNewVersion.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieAppNewVersion.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper=mapper;
        }
        public IActionResult CategoryList()
        {
            var categories = _mapper.Map<List<CategoryListDTO>>(_categoryService.GetCategoriesIncludeMovie());
            return View(categories);
        }
        [HttpGet]
        public ActionResult<Category> CategoryUpdate(int id)
        {
            var result =_mapper.Map<CategoryUpdateDTO>(_categoryService.GetByIdCategoryIncludeMovie(id));
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
                var categoryupdate= _mapper.Map<CategoryUpdateDTO, Category>(updateCategory);
                await _categoryService.Update(categoryupdate);
                return RedirectToAction("CategoryList");
            }
            return View(updateCategory);

        }
        [HttpGet]
        public IActionResult CategoryDeleteConfirmed(int id)
        {
            var result = _mapper.Map<CategoryDeleteDTO>(_categoryService.GetById(id));
            if (result != null)
            {
                return View(result);
            }
            return NotFound();
        }
        [HttpPost, ActionName("CategoryDeleteConfirmed")]
        public async Task<IActionResult> CategoryDelete(CategoryDeleteDTO category)
        {
            await _categoryService.Delete(category.CategoryId);
            return RedirectToAction("CategoryList");
        }
    }
}
