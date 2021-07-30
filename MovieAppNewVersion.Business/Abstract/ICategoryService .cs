﻿using MovieAppNewVersion.Entities.Concrete;

namespace MovieAppNewVersion.Business.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        Category GetCategoryByMovie(int id);
    }
}
