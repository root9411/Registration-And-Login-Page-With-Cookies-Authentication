using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Models
{
    public class LoginUser
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter Your Username !")]
        [Display(Name = "Email : ")]
        public string Uemail { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter Your Username !")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }
        public bool KeepLoggedIn { get; set; }

    }
}
