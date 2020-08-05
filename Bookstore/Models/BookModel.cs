using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Bookstore.Enums;
using Bookstore.Helpers;
using Microsoft.AspNetCore.Http;

namespace Bookstore.Models
{
    public class BookModel
    {
        /*[DataType(DataType.Date)]
        [Display(Name ="Chose date and time")]
        public string MyField { get; set; }*/
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Title")]
        [StringLength(100, MinimumLength = 5)]
        /*[MyCustomValidationAttribute]*/
        public string Title { get; set; }

        [Required(ErrorMessage = "Description cannot be empty.")]
        [StringLength(200,MinimumLength = 10)]
        public string Description { get; set; }

        [Required(ErrorMessage ="Author name cannot be empty.")]        
        public string Author { get; set; }
        [Display(Name = "Cover Image")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }
        
        public string Category { get; set; }
        [Required(ErrorMessage = "Please choose your book language.")]
        public string Language { get; set; }

        public LanguageEnum MultiLang { get; set; }
        [Required]
        [Display(Name ="Total pages of book")]
        public int? TotalPages { get; set; }
    }
}
