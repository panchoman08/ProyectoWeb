using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models.authenticate
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El usuario es un campo requerido.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es un campo requerido.")]
        public string Password { get; set; }
    }
}
