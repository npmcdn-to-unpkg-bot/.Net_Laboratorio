using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DALayer;
using System;
using System.Web;
using GameBuildPortal.Controllers;

namespace GameBuildPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    
    public class ApplicationDbContext : TenantContext
    { 
        public ApplicationDbContext(){
            this.SchemaName = Tenantcontroller.tenant;
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}