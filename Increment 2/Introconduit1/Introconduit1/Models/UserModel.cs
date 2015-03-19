using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Introconduit1.Models
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address:")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(200, MinimumLength = 6)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(200, MinimumLength = 6)]
        [Display(Name = "PasswordSalt:")]
        public string PasswordSalt { get; set; }
       

    }
}