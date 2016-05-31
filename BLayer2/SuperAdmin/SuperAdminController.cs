using BLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedEntities.Entities;
using DALayer.Interfaces;
using DALayer.Api;

namespace BLayer.SuperAdmin
{
    public class SuperAdminController : ISuperAdmin
    {
        ISuperAdminApi api;
        ISolicitudJuegoHandler handler;
        public SuperAdminController() {
            api = new SuperAdminApi();
            handler = api.getSJHandler();
        }

       

        public void createSolicitud(SolicitudJuego sol)
        {
            handler.createSolicitudJuego(sol);
        }

        public string getActivateURL(SolicitudJuego sol)
        {
            var URL = String.Format("/activate/create/{0}/{1}/{2}", Base64Encode(sol.user), Base64Encode(sol.password), Base64Encode(sol.token));
            return URL; 
        }
        public SolicitudJuego getSolicitudFromURL(string url) {
            string[] parse = url.Split('/');
            string token = Base64Decode(parse[parse.Length - 1]);
            string password = Base64Decode(parse[parse.Length - 2]);
            string user = Base64Decode(parse[parse.Length - 3]);
            return handler.getAllSolicitudes().Where(c => c.user.Equals(user) && c.password.Equals(password) && c.token.Equals(token)).First<SolicitudJuego>();
        }
        public SolicitudJuego getSolicitudByParam(string usuario, string password, string token)
        {
            token = Base64Decode(token);
            password = Base64Decode(password);
            usuario = Base64Decode(usuario);
            return handler.getAllSolicitudes().Where(c => c.user.Equals(usuario) && c.password.Equals(password) && c.token.Equals(token)).First<SolicitudJuego>();
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
