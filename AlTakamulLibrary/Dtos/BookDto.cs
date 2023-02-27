using AlTakamulLibrary.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlTakamulLibrary.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
    }
}
