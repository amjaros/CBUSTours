using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Capstone.Web.DataAccess;

namespace Capstone.Web.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "**Username field is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "**Email address field is required.")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[a-z])(?=.*\W).{6,15}$", ErrorMessage = "Password must be at least 6 characters long and have a number, an uppercase letter, a lowercase letter and a special character.")]
        public string Password { get; set; }

        public int User_Id { get; set; }

        public bool EnteredInvalidLogin { get; set; }
    }
}