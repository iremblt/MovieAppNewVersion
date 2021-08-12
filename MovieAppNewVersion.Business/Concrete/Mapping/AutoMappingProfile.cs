using AutoMapper;
using MovieAppNewVersion.DTO.DTOs.CategoryDTO;
using MovieAppNewVersion.DTO.DTOs.MovieDTO;
using MovieAppNewVersion.Entities.Concrete;
using static MovieAppNewVersion.DTO.DTOs.MovieCategoryDTO.MovieCategoryViewModelDTO;

namespace MovieAppNewVersion.Business.Concrete.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Movie, MovieAddDTO>().ReverseMap();
            CreateMap<Movie, MovieListDTO>().ReverseMap();
            CreateMap<Movie, MovieUpdateDTO>().ReverseMap();
            CreateMap<Movie, MovieDeleteDTO>().ReverseMap();
            CreateMap<Category, CategoryAddDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            CreateMap<Category, CategoryListDTO>().ReverseMap();
            CreateMap<Category, CategoryDeleteDTO>().ReverseMap();
            CreateMap<Movie, MovieViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Movie, MovieSearchDTO>().ReverseMap();
        }
    }
}
