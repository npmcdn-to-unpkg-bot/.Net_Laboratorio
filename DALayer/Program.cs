using System;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace DALayer
{
    class Program
    {
        public static object ConfigurationManager { get; private set; }

        static void Main(string[] args)
        {

             SetUpDataBase.checkIfExist();




            /**
                      AdminContext dbAdmin = new AdminContext();
           Entities.SolicitudJuego sj = new Entities.SolicitudJuego();
           sj.email = "rodrigo.rossi.trabal@gmail.com";
           sj.user =  Guid.NewGuid().ToString();
           sj.password = Guid.NewGuid().ToString();
           sj.token = DateTime.Now.ToString();
           dbAdmin.SolicitudJuegos.Add(sj);
           dbAdmin.SaveChangesAsync().Wait();
             var connection = new SqlConnectionFactory().CreateConnection("Admin");
             TenantContext.ProvisionTenant("ogame", connection);
             TenantContext.ProvisionTenant("ogame2", connection);
             var ctx = TenantContext.Create("ogame", connection);
             var ctx2 = TenantContext.Create("ogame2", connection);


             using (var db2 = new TenantContext("t1","orgame"))
             {
                 db2.Jugador.Add(new Entities.Jugador());
                 db2.SaveChangesAsync().Wait();
             }
             using (var db3 = new TenantContext("t2", "osrgame"))
             {
                 db3.Jugador.Add(new Entities.Jugador());
                 db3.SaveChangesAsync().Wait();
             }
                 */


            var tennant = "atenant" + DateTime.Now.Millisecond;
            var tennant1 = "atenant2" + DateTime.Now.Millisecond;
            // createTenant(tennant);
            // createTenant(tennant1);
            
            using (var db = new TenantContext(createTenant(tennant), tennant))
            {
                db.Jugador.Add(new Entities.Jugador());
                db.SaveChangesAsync().Wait();
            }

            using (var db2 = new TenantContext(createTenant(tennant1), tennant1))
            {
                db2.Jugador.Add(new Entities.Jugador());
                db2.SaveChangesAsync().Wait();
            } 
        }
        private static string createTenant(string tenantID)
        {
            

            var sqlConection = new SqlConnectionFactory().CreateConnection("atlas");
            // var connectionString = sqlConection.ConnectionString;
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Admin"].ConnectionString; 
            SqlConnection connection = new SqlConnection(connectionString);

            string loginName = String.Format("pass_{0}", tenantID);
            string userName = String.Format("user_{0}", tenantID);

            string loginSql = String.Format("use atlas;CREATE LOGIN {0} WITH PASSWORD = '{1}'", tenantID, loginName );
            string userSql = String.Format("use atlas; CREATE USER {0} FOR LOGIN {1}", userName, tenantID);
            string tenantSql = String.Format("CREATE SCHEMA {0} AUTHORIZATION {1}", tenantID, userName);
                      

            using (SqlConnection dbConn = connection)
            {
                dbConn.Open();

                using (SqlTransaction dbTrans = dbConn.BeginTransaction())
                {
                    
                    using (SqlCommand dbCommand = new SqlCommand(loginSql, dbConn))
                    {
                        dbCommand.Transaction = dbTrans;
                        dbCommand.ExecuteNonQuery();
                    }
                    using (SqlCommand dbCommand = new SqlCommand(userSql, dbConn))
                    {
                        dbCommand.Transaction = dbTrans;
                        dbCommand.ExecuteNonQuery();
                    }
                    using (SqlCommand dbCommand = new SqlCommand(tenantSql, dbConn))
                    {
                        dbCommand.Transaction = dbTrans;
                        dbCommand.ExecuteNonQuery();
                    }
                    dbTrans.Commit();
                }

                dbConn.Close();
            }
            return connectionString + ";User ID = " + userName + "; Password = " + loginName;
        }
    }
}
