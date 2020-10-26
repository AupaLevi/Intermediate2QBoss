using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate2QBoss
{
    class QbossSQLServerConductor
    {
        private SqlConnection sqlConnection;
        private ProjectStringPool projectStringPool = new ProjectStringPool();
        private string actionResult;


        string sql;

        public QbossSQLServerConductor()
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
                Console.Write("MySqlException :" + ex.Message);
                return false;
            }
        }

        public String InsertEi_MasterSQLServer(OraEi_MasterObject oraEi_Masters)
        {
            sql = "";
            ProjectStringPool stringPool = new ProjectStringPool();

            sql = stringPool.getInsSQLServerEi_MasterSQL();

            actionResult = "SUCCESS";
            OpenConnection();


            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sql;

                //sqlCommand.Parameters.AddWithValue("36", ei_master.Id);
                sqlCommand.Parameters.AddWithValue("@val02", oraEi_Masters.InvoiceNumber);
                sqlCommand.Parameters.AddWithValue("@val03", oraEi_Masters.Status);
                sqlCommand.Parameters.AddWithValue("@val04", oraEi_Masters.Purpose);
                sqlCommand.Parameters.AddWithValue("@val05", oraEi_Masters.InvoiceDate);
                sqlCommand.Parameters.AddWithValue("@val06", oraEi_Masters.CustomerID);
                sqlCommand.Parameters.AddWithValue("@val07", oraEi_Masters.CustomerName);
                sqlCommand.Parameters.AddWithValue("@val08", oraEi_Masters.CustomerTaxID);
                sqlCommand.Parameters.AddWithValue("@val09", oraEi_Masters.InvoiceType);
                sqlCommand.Parameters.AddWithValue("@val010", oraEi_Masters.PrintMark);
                sqlCommand.Parameters.AddWithValue("@val011", oraEi_Masters.RandomNumber);
                sqlCommand.Parameters.AddWithValue("@val012", oraEi_Masters.CarrierType);
                sqlCommand.Parameters.AddWithValue("@val013", oraEi_Masters.CarrierID);
                sqlCommand.Parameters.AddWithValue("@val014", oraEi_Masters.SalesAmount);
                sqlCommand.Parameters.AddWithValue("@val015", oraEi_Masters.FreeTaxSalesAmount);
                sqlCommand.Parameters.AddWithValue("@val016", oraEi_Masters.ZeroTaxSalesAmount);
                sqlCommand.Parameters.AddWithValue("@val017", oraEi_Masters.TaxAmount);
                sqlCommand.Parameters.AddWithValue("@val018", oraEi_Masters.TaxType);
                sqlCommand.Parameters.AddWithValue("@val019", oraEi_Masters.TaxRate);
                sqlCommand.Parameters.AddWithValue("@val020", oraEi_Masters.TotalAmount);
                sqlCommand.Parameters.AddWithValue("@val021", oraEi_Masters.DonateNo);
                sqlCommand.Parameters.AddWithValue("@val022", oraEi_Masters.DonateMark);
                sqlCommand.Parameters.AddWithValue("@val023", oraEi_Masters.Exported);
                sqlCommand.Parameters.AddWithValue("@val024", oraEi_Masters.GroupMark);
                sqlCommand.Parameters.AddWithValue("@val025", oraEi_Masters.SellerTaxID);
                sqlCommand.Parameters.AddWithValue("@val026", oraEi_Masters.SellerName);
                sqlCommand.Parameters.AddWithValue("@val027", oraEi_Masters.SellerAddress);
                sqlCommand.Parameters.AddWithValue("@val028", oraEi_Masters.MachineCode);
                sqlCommand.Parameters.AddWithValue("@val029", oraEi_Masters.MachineSerialNum);
                sqlCommand.Parameters.AddWithValue("@val030", oraEi_Masters.CancelExported);
                sqlCommand.Parameters.AddWithValue("@val031", oraEi_Masters.CancelReason);
                sqlCommand.Parameters.AddWithValue("@val032", oraEi_Masters.CancelTime);
                sqlCommand.Parameters.AddWithValue("@val033", oraEi_Masters.Notes);
                sqlCommand.Parameters.AddWithValue("@val034", oraEi_Masters.VoidExported);
                sqlCommand.Parameters.AddWithValue("@val035", oraEi_Masters.VoidReason);
                sqlCommand.Parameters.AddWithValue("@val036", oraEi_Masters.VoidTime);
                sqlCommand.Parameters.AddWithValue("@val037", oraEi_Masters.InErrorList);
                sqlCommand.Parameters.AddWithValue("@val038", oraEi_Masters.UploadStatus);
                sqlCommand.Parameters.AddWithValue("@val039", oraEi_Masters.UploadMessage);
                sqlCommand.Parameters.AddWithValue("@val040", oraEi_Masters.IOType);
                sqlCommand.Parameters.AddWithValue("@val041", oraEi_Masters.RejectReason);
                sqlCommand.Parameters.AddWithValue("@val042", oraEi_Masters.RejectTime);
                sqlCommand.Parameters.AddWithValue("@val043", oraEi_Masters.CreditCard);
                sqlCommand.Parameters.AddWithValue("@val044", oraEi_Masters.Cash);
                sqlCommand.Parameters.AddWithValue("@val045", oraEi_Masters.CashDiscount);
                sqlCommand.Parameters.AddWithValue("@val046", oraEi_Masters.InvoiceSpecies);
                sqlCommand.Parameters.AddWithValue("@val047", oraEi_Masters.InvType);
                sqlCommand.Parameters.AddWithValue("@val048", oraEi_Masters.OrderNo);
                sqlCommand.Parameters.AddWithValue("@val049", oraEi_Masters.CustomsClearanceMark);
                sqlCommand.Parameters.AddWithValue("@val050", oraEi_Masters.CreditCardLast4No);
                sqlCommand.Parameters.AddWithValue("@val051", oraEi_Masters.CustomerAddress);
                sqlCommand.Parameters.AddWithValue("@val052", oraEi_Masters.MessageBeginTime);
                sqlCommand.Parameters.AddWithValue("@val053", oraEi_Masters.WebPrintState);
                sqlCommand.Parameters.AddWithValue("@val054", oraEi_Masters.VAT);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write("SQLServer Ins Ei_Master Exception : " + ex.Message);
                actionResult = "FAIL";

            }
            finally
            {
                CloseConnection();
            }


            return actionResult;
        }

        public DataTable GetDataTable(String sql)
        {
            DataTable dataTable = null;
            OpenConnection();
            try
            {
                //string name = sqlConnection.ServiceName;
                CommonUntil commonUntil = new CommonUntil();
                //int year = commonUntil.getYear();
                SqlCommand sqlcommand = new SqlCommand(sql, this.sqlConnection);
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = sql;
                sqlcommand.CommandType = CommandType.Text;
                //OracleParameter[] parameters = new OracleParameter[] {
                //    new OracleParameter("val01",year),
                //    new OracleParameter("val02",month)
                //};
                //command.Parameters.AddRange(parameters);
                //sql = "SELECT * FROM tc_ome_file " +
                //        " WHERE tc_ome06 = '1' ";
                //OracleCommand command = new OracleCommand(sql, this.connection);
                SqlDataReader sqlDataReader = sqlcommand.ExecuteReader();

                dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQLConductor Excetpion" + ex.Message);
                PostalService postalService = new PostalService();
                postalService.SendMail("Levi.Huang@aupa.com.tw", "Intermediate Data Copier Alert", ex.Message);
            }
            finally
            {
                CloseConnection();
            }


            return dataTable;
        }

        public String InsertEi_DetailSQLServer(OraEi_DetailObject oraEi_Details)
        {
            sql = "";
            ProjectStringPool stringPool = new ProjectStringPool();

            sql = stringPool.getInsSQLServerEi_DetailSQL();

            actionResult = "SUCCESS";
            OpenConnection();

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sql;

                sqlCommand.Parameters.AddWithValue("@val00", oraEi_Details.InvoiceId);
                sqlCommand.Parameters.AddWithValue("@val01", oraEi_Details.ProductID);
                sqlCommand.Parameters.AddWithValue("@val02", oraEi_Details.Description);
                sqlCommand.Parameters.AddWithValue("@val03", oraEi_Details.Quantity);
                sqlCommand.Parameters.AddWithValue("@val04", oraEi_Details.Unit);
                sqlCommand.Parameters.AddWithValue("@val05", oraEi_Details.UnitPrice);
                sqlCommand.Parameters.AddWithValue("@val06", oraEi_Details.SequenceNumber);
                sqlCommand.Parameters.AddWithValue("@val07", oraEi_Details.Amount);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write("SQLServer Ins Ei_Ome Exception : " + ex.Message);
                actionResult = "FAIL";

            }
            finally
            {
                CloseConnection();
            }


            return actionResult;
        }

        
    }
}
