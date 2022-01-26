using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email/Username is required")]
        [Display(Name = "Email/Username")]
        public string EmailOrUsername { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
