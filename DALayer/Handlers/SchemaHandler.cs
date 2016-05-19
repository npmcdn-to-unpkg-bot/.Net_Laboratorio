using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class SchemaHandler
    {

        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Admin"].ConnectionString;
        public static string setUpConnection = System.Configuration.ConfigurationManager.ConnectionStrings["setUp"].ConnectionString; 
        public static string passwordConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["authorizedString"].ConnectionString;
        public const string DATA_BASE_NAME = "Atlas";
        private static bool checkDataBase() {

            return false;
        }
        private static void execMultiple(string[] commands, string connectionStr = null) {
            connectionStr = connectionStr == null ? connectionString : connectionStr;
            SqlConnection connection = new SqlConnection(connectionStr);
            using (SqlConnection dbConn = connection)
            {
                try
                {
                    dbConn.Open();
                    using (SqlTransaction dbTrans = dbConn.BeginTransaction())
                    {
                        for (var i = 0; i < commands.Length; i++)
                        {
                            using (SqlCommand dbCommand = new SqlCommand(commands[i], dbConn))
                            {
                                dbCommand.Transaction = dbTrans;
                                dbCommand.ExecuteNonQuery();
                            }
                        }

                        dbTrans.Commit();
                    }
                }
                catch (Exception e) {
                    dbConn.Close();
                    throw e;
                }
               
                dbConn.Close();
            }
        }
        public static String getTenantConnectionString(string tenantName) {
            return String.Format(passwordConnectionString, tenantName, getTenantPass(tenantName));
        }
        public static string getTenantUser(string tenantName) {

            return String.Format("user{0}", tenantName);
        }

        public static string getTenantPass(string tenantName) {

            return String.Format("pass{0}", tenantName);
        }
        public static void createTenant(string tenantID)
        {
            string loginName = getTenantPass(tenantID);
            string userName = getTenantUser(tenantID);

            string loginSql = String.Format("CREATE LOGIN {0} WITH PASSWORD = '{1}', DEFAULT_DATABASE=[{2}]", tenantID, loginName, DATA_BASE_NAME);
            string userSql = String.Format("CREATE USER {0} for login {1}", userName, tenantID);
            string grantRoleSql = String.Format("ALTER ROLE[db_owner] ADD MEMBER[{0}]", userName);
            string tenantSql = String.Format("CREATE SCHEMA {0} AUTHORIZATION {1}", tenantID, userName);
            string defaultSchemaSql = String.Format("ALTER USER {0} WITH DEFAULT_SCHEMA = {1}", userName, tenantID);
            /*loginSql createRoleSql, grantRoleSql, */
            string[] commands = { loginSql ,userSql, grantRoleSql, tenantSql , defaultSchemaSql };
            execMultiple(commands);
        }


        /*Esto no se va a usar pero no lo borren aun*/
        private static void createDataBase() {
            string createDataBase = String.Format("CREATE DATABASE [{0}]", DATA_BASE_NAME);
            SqlConnection connection = new SqlConnection(setUpConnection);
            using (SqlConnection dbConn = connection)
            {
                try
                {
                    dbConn.Open();
                    using (SqlCommand dbCommand = new SqlCommand(createDataBase, dbConn))
                    {
                        dbCommand.ExecuteNonQuery();
                    }

                }
                catch (Exception e)
                {
                    dbConn.Close();
                    throw e;
                }

                dbConn.Close();
            }
        }
        private static void checkDBExist() {
            string checkDB = String.Format("SELECT COUNT(*) FROM master.dbo.sysdatabases WHERE name = '{0}';", DATA_BASE_NAME);
           
            SqlConnection connection = new SqlConnection(setUpConnection);
            using (SqlConnection dbConn = connection)
            {
                try
                {
                    dbConn.Open();

                    using (SqlTransaction dbTrans = dbConn.BeginTransaction())
                    {

                        using (SqlCommand dbCommand = new SqlCommand(checkDB, dbConn))
                        {
                            dbCommand.Transaction = dbTrans;
                            if ((int)dbCommand.ExecuteScalar() != 1)
                            {
                                createDataBase();
                            }

                        }

                        dbTrans.Commit();
                    }

                    dbConn.Close();
                }
                catch (SqlException e) {
                    dbConn.Close();
                    throw e; 
                }
            }

        }
    }
}
