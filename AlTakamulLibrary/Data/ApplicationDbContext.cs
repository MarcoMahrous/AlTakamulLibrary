using Microsoft.EntityFrameworkCore;
using AlTakamulLibrary.Models;
using AlTakamulLibrary.Dtos;

namespace AlTakamulLibrary.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDto> BookDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookDto>(b=> { b.HasNoKey().ToView(null); });
        }
    }
}
