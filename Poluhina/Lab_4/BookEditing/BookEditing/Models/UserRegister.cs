using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookEditing.Models
{
    public class UserRegister
    {        
            [Required]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [Compare("Password", ErrorMessage = "Passwords aren't the same")]
            [DataType(DataType.Password)]
            public string PasswordConfirm { get; set; }
    }
}