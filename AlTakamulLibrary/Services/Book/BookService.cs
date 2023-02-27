using AlTakamulLibrary.Data;
using AlTakamulLibrary.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AlTakamulLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponse<Book>> Create(Book book)
        {
            try
            {
                await _context.Books.AddAsync(book);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<Book>() { Success = true, Model = book };
                return new GeneralResponse<Book>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<Book>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }

        public async Task<GeneralResponse<Book>> Delete(Book book)
        {
            try
            {
                _context.Books.Remove(book);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<Book>() { Success = true, Model = book };
                return new GeneralResponse<Book>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<Book>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }

        public async Task<Book> Get(int id)
        {
            return await _context.Books.Include(a=> a.Author).Include(c=> c.BookCategory).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Book>> Get()
        {
            return await _context.Books.Include(a => a.Author).Include(c => c.BookCategory).ToListAsync();
        }

        public async Task<BookDto> GetStoredProcedure(int id)
        {
            var books = await _context.BookDto.FromSqlRaw($"prc_GetAllBooksById {id}").ToListAsync();
            return books?.FirstOrDefault();
        }

        public async Task<List<BookDto>> GetStoredProcedure()
        {
            return await _context.BookDto.FromSqlRaw("prc_GetAllBooks").ToListAsync();
        }

        public async Task<GeneralResponse<Book>> Update(Book book)
        {
            try
            {
                _context.Books.Update(book);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<Book>() { Success = true, Model = book };
                return new GeneralResponse<Book>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<Book>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }
    }
}
