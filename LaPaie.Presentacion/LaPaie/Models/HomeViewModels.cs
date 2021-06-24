using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LaPaie.Models
{
    public class HomeViewModels
    {
        
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nick")]
        public string Nick { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "ErrorLogin")]
        public string ErrorLogin { get; set; }

        public LoginViewModel()
        {
            ErrorLogin = "";
        }
    }
}