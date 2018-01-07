using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAccount.Models
{
    public class LoginVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        //Eğer true ise oturum kendi gübenlik poliçesi kullanılır 45 dk oturum açar.
        //eğer false ise tarayıcı kapandığında oturumda kapanır.
        public bool RememberMe { get; set; }


    }
}