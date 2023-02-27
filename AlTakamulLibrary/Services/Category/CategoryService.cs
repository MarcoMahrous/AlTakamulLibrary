using AlTakamulLibrary.Data;
using AlTakamulLibrary.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AlTakamulLibrary.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponse<Category>> Create(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<Category>() { Success = true, Model = category };
                return new GeneralResponse<Category>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<Category>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }

        public async Task<GeneralResponse<Category>> Delete(Category category)
        {
            try
            {
                _context.Categories.Remove(category);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<Category>() { Success = true, Model = category };
                return new GeneralResponse<Category>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<Category>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }

        public async Task<Category> Get(int id)
        {
            return await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<GeneralResponse<Category>> Update(Category category)
        {
            try
            {
                _context.Categories.Update(category);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<Category>() { Success = true, Model = category };
                return new GeneralResponse<Category>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<Category>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }
    }
}
