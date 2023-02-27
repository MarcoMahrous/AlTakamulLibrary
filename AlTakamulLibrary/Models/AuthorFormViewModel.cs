using AlTakamulLibrary.Data;
using System.ComponentModel.DataAnnotations;

namespace AlTakamulLibrary.Models
{
    public class AuthorFormViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Name { get; set; }
    }
}
