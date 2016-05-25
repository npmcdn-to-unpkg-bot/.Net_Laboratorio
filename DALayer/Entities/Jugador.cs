using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Entities
{
    public class Jugador: Usuario
    {
        public string nickname { get; set; }
        public int nivel { get; set; }
        public float experiencia { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Jugador> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
