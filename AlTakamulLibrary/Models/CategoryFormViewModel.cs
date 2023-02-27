using AlTakamulLibrary.Data;
using System.ComponentModel.DataAnnotations;

namespace AlTakamulLibrary.Models
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(250)]
        public string Name { get; set; }
    }
}
