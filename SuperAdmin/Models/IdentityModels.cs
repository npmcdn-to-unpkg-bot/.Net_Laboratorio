using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SuperAdmin.Models
{
 

    public class ApplicationDbContext : DALayer.AdminContext
    {

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}