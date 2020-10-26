using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate2QBoss
{
    class OracleDBConductor
    {
        private OracleConnection connection;
        private ProjectStringPool projectStringPool = new ProjectStringPool();



        public OracleDBConductor()
        {
            Initializer();
        }

        private void Initializer()
        {
            string connectionString;
            //connectionString = GetConnectionString("192.168.168.249", "1521", "topprod", "aupa_prod", "Cc123456");
            connectionString = projectStringPool.getOracleConnectionString("192.168.168.249", "1521", "toptest", "aupa_prod", "aupa_prod");
            connection = new OracleConnection(connectionString);
        }

        private bool OpenOracleConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Oracle Side Exception :" + ex.Message);
                return false;
                throw;
            }
        }

        private bool CloseOracleConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("CloseOracleConnectionException :" + ex.Message);
                return false;
                throw;
            }
        }

        public DataTable GetDataTable(String sql)
        {
            DataTable dataTable = null;
            OpenOracleConnection();
            try
            {
                string name = connection.ServiceName;
                CommonUntil commonUntil = new CommonUntil();
                //int year = commonUntil.getYear();
                OracleCommand command = new OracleCommand(sql, this.connection);
                command.Connection = connection;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;
                //OracleParameter[] parameters = new OracleParameter[] {
                //    new OracleParameter("val01",year),
                //    new OracleParameter("val02",month)
                //};
                //command.Parameters.AddRange(parameters);
                //sql = "SELECT * FROM tc_ome_file " +
                //        " WHERE tc_ome06 = '1' ";
                //OracleCommand command = new OracleCommand(sql, this.connection);
                OracleDataReader oracleDataReader = command.ExecuteReader();

                dataTable = new DataTable();
                dataTable.Load(oracleDataReader);
            }
            catch (Exception ex)
            {
                Console.WriteLine("OraDBConductor Excetpion" + ex.Message);
                PostalService postalService = new PostalService();
                postalService.SendMail("Levi.Huang@aupa.com.tw", "Intermediate Data Copier Alert", ex.Message);
            }
            finally
            {
                CloseOracleConnection();
            }


            return dataTable;
        }
    }
}
