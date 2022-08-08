﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage ="Enter UserName!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Enter Password!")]
        public string Password { get; set; }
    }
}