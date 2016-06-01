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
        [StringLength(15, ErrorMessage = "El nombre {0} es muy largo", MinimumLength = 6)]
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
        [StringLength(15, ErrorMessage = "El nombre {0} es muy largo", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre Completo")]
        public String nombre { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "El nombre {0} es muy largo", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre Completo")]
        public String apellido { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "El nombre {0} es muy largo", MinimumLength = 6)]
        [DataType(DataType.Upload)]
        [Display(Name = "Nombre Completo")]
        public byte[] foto { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Email")]
        public String Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
 
        [Required] 
        [DataType(DataType.PhoneNumber)] 
        [Display(Name = "Telefono")]
        public string teléfono { get; set; }


    }
}