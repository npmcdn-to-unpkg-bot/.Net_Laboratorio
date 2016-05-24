using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameBuildPortal.Models
{
    public class ActivateGame
    {
        [Required]
        [StringLength(15, ErrorMessage = "El nombre {0} es muy largo", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre del Juego")]
        public string nombreJuego { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "El nombre {0} es muy largo", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre Completo")]
        public string nombre { get; set; }
        [Required] 
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public string fNac { get; set; }
        [Required] 
        [DataType(DataType.PhoneNumber)] 
        [Display(Name = "Telefono")]
        public string teléfono { get; set; }


    }
}