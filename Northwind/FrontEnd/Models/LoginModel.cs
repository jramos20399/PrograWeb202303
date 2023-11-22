using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class LoginModel
    {


        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }

        public List<string> roles { get; set; }

    }
}
