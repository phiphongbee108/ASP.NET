using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Required(ErrorMessage = "Enter UserName!")]
        public string UserName { set; get; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password must be at least 6 charecters!")]
        [Required(ErrorMessage = "Enter Password!")]
        public string Password { set; get; }

        [Compare("Password", ErrorMessage = "Confirm password does not match!")]
        public string ConfirmPassword { set; get; }

        [Required(ErrorMessage = "Enter Name!")]
        public string Name { set; get; }
        public string Address { set; get; }

        [Required(ErrorMessage = "Enter Email!")]
        public string Email { set; get; }
        public string Phone { set; get; }
        public string ProvinceID { set; get; }
        public string DistrictID { set; get; }
        public string CaptchaCode { get; set; }
    }
}