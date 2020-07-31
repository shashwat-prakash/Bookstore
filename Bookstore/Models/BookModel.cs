using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Title")]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description cannot be empty.")]
        [StringLength(200,MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage ="Author name cannot be empty.")]        
        public string Author { get; set; }

        
        public string Category { get; set; }
        public string Language { get; set; }
        [Required]
        [Display(Name ="Total pages of book")]
        public int? TotalPages { get; set; }
    }
}
