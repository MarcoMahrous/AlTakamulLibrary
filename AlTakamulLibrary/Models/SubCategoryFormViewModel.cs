using AlTakamulLibrary.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlTakamulLibrary.Models
{
    public class SubCategoryFormViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Name { get; set; }
        [Display(Name = "Category")]
        [Required, Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public IEnumerable<Category>? categories { get; set; }

    }
}
