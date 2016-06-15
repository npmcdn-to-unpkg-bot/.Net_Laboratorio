using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SharedEntities.Entities;

namespace GameBuildPortal.Models
{
    public class LayoutViewModel
    {
        public ExternalLoginConfirmationViewModel ExternalLoginConfirmationViewModel { get; set; }
        public ExternalLoginListViewModel ExternalLoginListViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public Configuracion Configuracion { get; set; }
        public VerifyCodeViewModel VerifyCodeViewModel { get; set; }
    }
}
