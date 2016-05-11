using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer
{
    public class SetUpDataBase
    {

        public static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Admin"].ConnectionString;
        public static string setUpConnection = System.Configuration.ConfigurationManager.ConnectionStrings["setUp"].ConnectionString; 
        public static string passwordConnectionString = connectionString + ";User ID = {0}; Password = {1}";
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
        private static void exec(string command, string connectionStr = null)
        {
            connectionStr = connectionStr == null ? connectionString : connectionStr;
            SqlConnection connection = new SqlConnection(connectionStr);
            using (SqlConnection dbConn = connection)
            {
                try
                {
                    dbConn.Open();
                    using (SqlTransaction dbTrans = dbConn.BeginTransaction())
                    {
                     
                        using (SqlCommand dbCommand = new SqlCommand(command, dbConn))
                        {
                            dbCommand.Transaction = dbTrans;
                            dbCommand.ExecuteNonQuery();
                        } 

                        dbTrans.Commit();
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
        private static void createTenant(string tenantID)
        {
            string loginName = String.Format("pass_{0}", tenantID);
            string userName = String.Format("user_{0}", tenantID);

            string loginSql = String.Format("use atlas;CREATE LOGIN {0} WITH PASSWORD = '{1}'", tenantID, loginName);
            string userSql = String.Format("use atlas; CREATE USER {0} FOR LOGIN {1}", userName, tenantID);
            string tenantSql = String.Format("CREATE SCHEMA {0} AUTHORIZATION {1}", tenantID, userName);
            string[] commands = { loginSql, userSql, tenantSql };
            execMultiple(commands);
        }
        private static void createDataBase() {
            string createDataBase = String.Format("CREATE DATABASE {0};", DATA_BASE_NAME);
            exec(createDataBase, setUpConnection);
        }
        
        public static void checkIfExist() {
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
