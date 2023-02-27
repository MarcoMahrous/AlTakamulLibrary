using AlTakamulLibrary.Data;
using AlTakamulLibrary.Dtos;

namespace AlTakamulLibrary.Services
{
    public interface ICategoryService
    {
        Task<GeneralResponse<Category>> Create(Category category);
        Task<GeneralResponse<Category>> Update(Category category);
        Task<GeneralResponse<Category>> Delete(Category category);
        Task<Category> Get(int id);
        Task<List<Category>> Get();
    }
}
