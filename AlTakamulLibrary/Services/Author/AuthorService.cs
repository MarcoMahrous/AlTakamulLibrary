using AlTakamulLibrary.Data;
using AlTakamulLibrary.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AlTakamulLibrary.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponse<Author>> Create(Author author)
        {
            try
            {
                await _context.Authors.AddAsync(author);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<Author>() { Success = true ,Model = author};
                return new GeneralResponse<Author>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {  
                return new GeneralResponse<Author>
                {
                    Error = "General Error!" ,
                    Success = false
                };
            }
        }

        public async Task<GeneralResponse<Author>> Delete(Author author)
        {
            try
            {
                _context.Authors.Remove(author);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<Author>() { Success = true, Model = author };
                return new GeneralResponse<Author>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<Author>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }

        public async Task<Author> Get(int id)
        {
            return await _context.Authors.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Author>> Get()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<GeneralResponse<Author>> Update(Author author)
        {
            try
            {
                _context.Authors.Update(author);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<Author>() { Success = true, Model = author };
                return new GeneralResponse<Author>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<Author>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }
    }
}
