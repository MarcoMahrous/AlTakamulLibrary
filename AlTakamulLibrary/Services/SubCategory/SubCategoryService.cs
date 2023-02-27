using AlTakamulLibrary.Data;
using AlTakamulLibrary.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AlTakamulLibrary.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponse<SubCategory>> Create(SubCategory item)
        {
            try
            {
                await _context.SubCategories.AddAsync(item);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<SubCategory>() { Success = true, Model = item };
                return new GeneralResponse<SubCategory>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<SubCategory>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }

        public async Task<GeneralResponse<SubCategory>> Delete(SubCategory item)
        {
            try
            {
                _context.SubCategories.Remove(item);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<SubCategory>() { Success = true, Model = item };
                return new GeneralResponse<SubCategory>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<SubCategory>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }

        public async Task<SubCategory> Get(int id)
        {
            return await _context.SubCategories.Include(x => x.Category).SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<SubCategory>> Get()
        {
            return await _context.SubCategories.Include(x=> x.Category).ToListAsync();
        }

        public async Task<GeneralResponse<SubCategory>> Update(SubCategory item)
        {
            try
            {
                _context.SubCategories.Update(item);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return new GeneralResponse<SubCategory>() { Success = true, Model = item };
                return new GeneralResponse<SubCategory>() { Success = false, Error = "Error in save Data", };
            }
            catch (Exception ex)
            {
                return new GeneralResponse<SubCategory>
                {
                    Error = "General Error!",
                    Success = false
                };
            }
        }
    }
}
