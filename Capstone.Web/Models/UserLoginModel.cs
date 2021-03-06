﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "**Username field is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "**Password is required.")]
        public string Password { get; set; }

        public int User_Id { get; set; }

        public bool EnteredInvalidLogin { get; set; }
    }
}