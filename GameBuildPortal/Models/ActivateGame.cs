using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameBuildPortal.Models
{
    public class ActivateGame
    {

        /*Datos del tenant*/
        [Required]
        [StringLength(15, ErrorMessage = "El nombre {0} es muy corto", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del Juego")]
        public string nombreJuego { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Dominio del juego")]
        public string dominio { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        /*Datos admin*/
        [Required]
        [StringLength(15, ErrorMessage = "El nombre {0} es muy corto", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public String nombre { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "El nombre {0} es muy corto", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Apellido")]
        public String apellido { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "El apellido {0} es muy corto", MinimumLength = 2)]
        [DataType(DataType.Upload)]
        [Display(Name = "Nombre Completo")]
        public byte[] foto { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        public String Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "El mail no es el correcto", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Clave")]
        [Compare("Password", ErrorMessage = "Las claves no coinciden.")]
        public string ConfirmPassword { get; set; }
 
        [Required] 
        [DataType(DataType.PhoneNumber)] 
        [Display(Name = "Telefono")]
        public string teléfono { get; set; }


    }
}