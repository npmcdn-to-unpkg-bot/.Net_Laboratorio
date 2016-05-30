using DALayer.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace GameBuildPortal.Modules
{
    public class UsuarioHelper
    {
        ApplicationUserManager _userManager;
        private string _Id;
        private Jugador jgr;
        private Admin adm;

        public bool isLogged { get; private set; }
        public bool isAdmin { get; private set; }

        public UsuarioHelper(ApplicationUserManager _userManager, string id)
        {
            this._userManager = _userManager;
            this._Id = id;
            RefreshUser();
        }

        public void RefreshUser() {
            var user = _userManager.FindById(_Id);
            if(user != null)
            {
                isLogged = true;
                var userType = user.GetType();
                if (userType.BaseType.FullName == typeof(Jugador).FullName)
                {
                    isAdmin = false;
                    jgr = (Jugador)user;
                }
                if (userType.BaseType.FullName == typeof(Admin).FullName)
                {
                    isAdmin = true;
                    adm = (Admin)user;
                }
            }
            else
            {
                isAdmin = false;
                isLogged = false;
            }
            
        }

        public Jugador getJugador() {
            if (!isAdmin)
            {
                return jgr;
            }
            return null;
        }

        public Admin getAdmin()
        {
            if (isAdmin)
            {
                return adm;
            }
            return null;
        }
    }


}