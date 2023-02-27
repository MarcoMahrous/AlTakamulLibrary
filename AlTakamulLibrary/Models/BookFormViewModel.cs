using AlTakamulLibrary.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlTakamulLibrary.Models
{
    public class BookFormViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Author")]
        [Required, Range(1, int.MaxValue)]
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author? Author { get; set; }
        [Display(Name = "BookCategory")]
        [Required, Range(1, int.MaxValue)]
        public int BookCategoryId { get; set; }
        [ForeignKey(nameof(BookCategoryId))]
        public SubCategory? BookCategory { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<SubCategory>? SubCategories { get; set; } = new List<SubCategory>();
        public IEnumerable<Author>? Authors { get; set; }
    }
}
