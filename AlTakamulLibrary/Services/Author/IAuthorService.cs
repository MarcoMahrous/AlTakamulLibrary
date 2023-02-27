using AlTakamulLibrary.Data;
using AlTakamulLibrary.Dtos;

namespace AlTakamulLibrary.Services
{
    public interface IAuthorService
    {
        Task<GeneralResponse<Author>> Create(Author author);
        Task<GeneralResponse<Author>> Update(Author author);
        Task<GeneralResponse<Author>> Delete(Author author);
        Task<Author> Get(int id);
        Task<List<Author>> Get();
    }
}
