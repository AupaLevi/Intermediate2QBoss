using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate2QBoss
{
    class SQLServerDataSecuricor
    {
        private SqlConnection sqlConnection;

        string sql;
        int dataCount;

        public SQLServerDataSecuricor()
        {
            Initializer();
        }
        private void Initializer()
        {
            SqlConnectionStringBuilder Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = "AUPA-EAI\\SQLEXPRESSINV";
            Builder.InitialCatalog = "i-Free-TEST";
            Builder.UserID = "sa";
            Builder.Password = "#Aupa=234";
            String sqlConnectionString = Builder.ConnectionString;
            sqlConnection = new SqlConnection(sqlConnectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                sqlConnection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;
                    case 53:
                        Console.WriteLine("40 - 無法開啟至 SQL Server 的連接");
                        break;
                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                sqlConnection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message);
                Console.WriteLine("MySqlException :" + ex.Message);
                return false;
            }
        }
        public int SelectEi_MasterRowCounts(string Key1)
        {
            OpenConnection();

            dataCount = 0;
            try
            {
                sql = "SELECT COUNT(invoiceNumber) FROM einvoiceMaster " +
                " WHERE invoiceNumber='" + Key1 + "'";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sql;

                dataCount = Convert.ToInt16(sqlCommand.ExecuteScalar());
                if (dataCount == -1)
                {
                    dataCount = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQLServer Data Secure Error : " + ex.Message);
                sqlConnection.Close();
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataCount;
        }

        public int SelectEi_DetailRowCounts(string Key1)
        {
            OpenConnection();

            dataCount = 0;
            try
            {
                sql = "SELECT COUNT(ProductID) FROM EInvoiceDetail " +
                " WHERE ProductID='" + Key1 + "'";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sql;

                dataCount = Convert.ToInt16(sqlCommand.ExecuteScalar());
                if (dataCount == -1)
                {
                    dataCount = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQLServer Data Secure Error : " + ex.Message);
                sqlConnection.Close();
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataCount;
        }

        public int SelectEi_MasterIDRowCounts(int Key1)
        {
            OpenConnection();

            dataCount = 0;
            try
            {
                sql = "SELECT COUNT(Id) FROM EInvoiceMaster " +
                " WHERE Id='" + Key1 + "'";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sql;



                dataCount = Convert.ToInt16(sqlCommand.ExecuteScalar());
                if (dataCount == -1)
                {
                    dataCount = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQLServer Data Secure Error : " + ex.Message);
                sqlConnection.Close();
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataCount;
        }

        public int SelectEi_MasterMacNumRowCounts(int Key1)
        {
            OpenConnection();

            dataCount = 0;
            try
            {
                sql = "SELECT COUNT(Id) FROM EInvoiceMaster " +
                " WHERE MachineSerialNum='" + Key1 + "'";

                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sql;



                dataCount = Convert.ToInt16(sqlCommand.ExecuteScalar());
                if (dataCount == -1)
                {
                    dataCount = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQLServer Data Secure Error : " + ex.Message);
                sqlConnection.Close();
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataCount;
        }
    }
}
