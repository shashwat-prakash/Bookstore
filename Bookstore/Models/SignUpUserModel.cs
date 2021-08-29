using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your Firstname")]
        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Lastname")]
        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Please enter your Email")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong Password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
