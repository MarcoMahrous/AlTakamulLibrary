using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlTakamulLibrary.Data
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }
        public int BookCategoryId { get; set; }
        [ForeignKey(nameof(BookCategoryId))]
        public SubCategory BookCategory { get; set; }
    }
}
