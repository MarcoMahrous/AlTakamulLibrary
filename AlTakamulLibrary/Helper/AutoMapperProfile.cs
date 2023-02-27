using AlTakamulLibrary.Data;
using AlTakamulLibrary.Models;
using AutoMapper;

namespace AlTakamulLibrary.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorFormViewModel>().ReverseMap();
            CreateMap<Category, CategoryFormViewModel>().ReverseMap();
            CreateMap<SubCategory, SubCategoryFormViewModel>().ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category)).ReverseMap();
            CreateMap<Book, BookFormViewModel>().ForMember(dest => dest.BookCategory, opt => opt.MapFrom(src => src.BookCategory))
                                                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                                                .ReverseMap();
        }
    }
}
