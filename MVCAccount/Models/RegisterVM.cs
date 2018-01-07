using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAccount.Models
{
    public class RegisterVM
    {
        [EmailAddress][Required]
        public string Email { get; set; }

        [Required][RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,12}$")]
        public string Password { get; set; }

        [Compare("Password")]
        public string PasswordConfirm { get; set; }

    }
}