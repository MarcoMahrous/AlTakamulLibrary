using AlTakamulLibrary.Data;
using AlTakamulLibrary.Dtos;

namespace AlTakamulLibrary.Services
{
    public interface IBookService
    {
        Task<GeneralResponse<Book>> Create(Book book);
        Task<GeneralResponse<Book>> Update(Book book);
        Task<GeneralResponse<Book>> Delete(Book book);
        Task<Book> Get(int id);
        Task<List<Book>> Get();

        //Stored Procedure
        Task<BookDto> GetStoredProcedure(int id);
        Task<List<BookDto>> GetStoredProcedure();
    }
}
