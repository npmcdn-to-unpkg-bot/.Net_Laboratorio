using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperAdmin.Models
{
    public class SolicitudJuegoModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Dirreccion de email del cliente")]
        public String email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Tiempo de expiracion")]
        public DateTime expirationTime { get; set; }
    }
}