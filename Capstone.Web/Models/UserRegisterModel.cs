using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "**Username field is required.")]
        public string User_name { get; set; }

        [Required(ErrorMessage = "**Email address field is required.")]
        [EmailAddress]
        public string User_email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Passord")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[a-z])(?=.*\W).{6,15}$", ErrorMessage = "Password must be at least 6 characters long and have 3 of the following: a number, an uppercase letter, a lowercase letter, or a special character.")]
        public string User_password { get; set; }

        public bool EnteredInvalidLogin { get; set; }
    }
}