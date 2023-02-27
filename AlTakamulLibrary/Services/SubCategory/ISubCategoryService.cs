using AlTakamulLibrary.Data;
using AlTakamulLibrary.Dtos;

namespace AlTakamulLibrary.Services
{
    public interface ISubCategoryService
    {
        Task<GeneralResponse<SubCategory>> Create(SubCategory item);
        Task<GeneralResponse<SubCategory>> Update(SubCategory item);
        Task<GeneralResponse<SubCategory>> Delete(SubCategory item);
        Task<SubCategory> Get(int id);
        Task<List<SubCategory>> Get();
    }
}
