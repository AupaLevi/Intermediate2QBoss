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
        private int deletedRows;

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

        public List<OraEi_MasterObject> InsertEi_MasterSQLServer(List<OraEi_MasterObject> oraEi_Masters)
        {
            sql = "";
            ProjectStringPool stringPool = new ProjectStringPool();
            List<OraEi_MasterObject> insertedEi_MasterObjects = new List<OraEi_MasterObject>();
            sql = stringPool.getInsSQLServerEi_MasterSQL();

            actionResult = "SUCCESS";
            OpenConnection();
            if (oraEi_Masters.Count > 0)
            {
                foreach (OraEi_MasterObject ei_master in oraEi_Masters)
                {
                    try
                    {
                        SqlCommand sqlCommand = sqlConnection.CreateCommand();
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = sql;

                        //sqlCommand.Parameters.AddWithValue("36", ei_master.Id);
                        sqlCommand.Parameters.AddWithValue("@val02", ei_master.InvoiceNumber);
                        sqlCommand.Parameters.AddWithValue("@val03", ei_master.Status);
                        sqlCommand.Parameters.AddWithValue("@val04", ei_master.Purpose);
                        sqlCommand.Parameters.AddWithValue("@val05", ei_master.InvoiceDate);
                        sqlCommand.Parameters.AddWithValue("@val06", ei_master.CustomerID);
                        sqlCommand.Parameters.AddWithValue("@val07", ei_master.CustomerName);
                        sqlCommand.Parameters.AddWithValue("@val08", ei_master.CustomerTaxID);
                        sqlCommand.Parameters.AddWithValue("@val09", ei_master.InvoiceType);
                        sqlCommand.Parameters.AddWithValue("@val010", ei_master.PrintMark);
                        sqlCommand.Parameters.AddWithValue("@val011", ei_master.RandomNumber);
                        sqlCommand.Parameters.AddWithValue("@val012", ei_master.CarrierType);
                        sqlCommand.Parameters.AddWithValue("@val013", ei_master.CarrierID);
                        sqlCommand.Parameters.AddWithValue("@val014", ei_master.SalesAmount);
                        sqlCommand.Parameters.AddWithValue("@val015", ei_master.FreeTaxSalesAmount);
                        sqlCommand.Parameters.AddWithValue("@val016", ei_master.ZeroTaxSalesAmount);
                        sqlCommand.Parameters.AddWithValue("@val017", ei_master.TaxAmount);
                        sqlCommand.Parameters.AddWithValue("@val018", ei_master.TaxType);
                        sqlCommand.Parameters.AddWithValue("@val019", ei_master.TaxRate);
                        sqlCommand.Parameters.AddWithValue("@val020", ei_master.TotalAmount);
                        sqlCommand.Parameters.AddWithValue("@val021", ei_master.DonateNo);
                        sqlCommand.Parameters.AddWithValue("@val022", ei_master.DonateMark);
                        sqlCommand.Parameters.AddWithValue("@val023", ei_master.Exported);
                        sqlCommand.Parameters.AddWithValue("@val024", ei_master.GroupMark);
                        sqlCommand.Parameters.AddWithValue("@val025", ei_master.SellerTaxID);
                        sqlCommand.Parameters.AddWithValue("@val026", ei_master.SellerName);
                        sqlCommand.Parameters.AddWithValue("@val027", ei_master.SellerAddress);
                        sqlCommand.Parameters.AddWithValue("@val028", ei_master.MachineCode);
                        sqlCommand.Parameters.AddWithValue("@val029", ei_master.MachineSerialNum);
                        sqlCommand.Parameters.AddWithValue("@val030", ei_master.CancelExported);
                        sqlCommand.Parameters.AddWithValue("@val031", ei_master.CancelReason);
                        sqlCommand.Parameters.AddWithValue("@val032", ei_master.CancelTime);
                        sqlCommand.Parameters.AddWithValue("@val033", ei_master.Notes);
                        sqlCommand.Parameters.AddWithValue("@val034", ei_master.VoidExported);
                        sqlCommand.Parameters.AddWithValue("@val035", ei_master.VoidReason);
                        sqlCommand.Parameters.AddWithValue("@val036", ei_master.VoidTime);
                        sqlCommand.Parameters.AddWithValue("@val037", ei_master.InErrorList);
                        sqlCommand.Parameters.AddWithValue("@val038", ei_master.UploadStatus);
                        sqlCommand.Parameters.AddWithValue("@val039", ei_master.UploadMessage);
                        sqlCommand.Parameters.AddWithValue("@val040", ei_master.IOType);
                        sqlCommand.Parameters.AddWithValue("@val041", ei_master.RejectReason);
                        sqlCommand.Parameters.AddWithValue("@val042", ei_master.RejectTime);
                        sqlCommand.Parameters.AddWithValue("@val043", ei_master.CreditCard);
                        sqlCommand.Parameters.AddWithValue("@val044", ei_master.Cash);
                        sqlCommand.Parameters.AddWithValue("@val045", ei_master.CashDiscount);
                        sqlCommand.Parameters.AddWithValue("@val046", ei_master.InvoiceSpecies);
                        sqlCommand.Parameters.AddWithValue("@val047", ei_master.InvType);
                        sqlCommand.Parameters.AddWithValue("@val048", ei_master.OrderNo);
                        sqlCommand.Parameters.AddWithValue("@val049", ei_master.CustomsClearanceMark);
                        sqlCommand.Parameters.AddWithValue("@val050", ei_master.CreditCardLast4No);
                        sqlCommand.Parameters.AddWithValue("@val051", ei_master.CustomerAddress);
                        sqlCommand.Parameters.AddWithValue("@val052", ei_master.MessageBeginTime);
                        sqlCommand.Parameters.AddWithValue("@val053", ei_master.WebPrintState);
                        sqlCommand.Parameters.AddWithValue("@val054", ei_master.VAT);

                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.Write("SQLServer Ins Ei_Master Exception : " + ex.Message);
                        actionResult = "FAIL";
                        break;
                    }
                    finally
                    {
                        if (actionResult == "SUCCESS")
                        {
                            insertedEi_MasterObjects.Add(ei_master);
                        }
                    }
                }
            }
            return insertedEi_MasterObjects;
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

        public List<OraEi_DetailObject> InsertEi_DetailSQLServer(List<OraEi_DetailObject> oraEi_Details)
        {
            sql = "";
            ProjectStringPool stringPool = new ProjectStringPool();
            List<OraEi_DetailObject> insertedEi_DetailObjects = new List<OraEi_DetailObject>();
            sql = stringPool.getInsSQLServerEi_DetailSQL();

            actionResult = "SUCCESS";
            OpenConnection();
            if (oraEi_Details.Count > 0)
            {
                foreach (OraEi_DetailObject ei_detail in oraEi_Details)
                {
                    try
                    {
                        SqlCommand sqlCommand = sqlConnection.CreateCommand();
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = sql;

                        sqlCommand.Parameters.AddWithValue("@val00", ei_detail.InvoiceId);
                        sqlCommand.Parameters.AddWithValue("@val01", ei_detail.ProductID);
                        sqlCommand.Parameters.AddWithValue("@val02", ei_detail.Description);
                        sqlCommand.Parameters.AddWithValue("@val03", ei_detail.Quantity);
                        sqlCommand.Parameters.AddWithValue("@val04", ei_detail.Unit);
                        sqlCommand.Parameters.AddWithValue("@val05", ei_detail.UnitPrice);
                        sqlCommand.Parameters.AddWithValue("@val06", ei_detail.SequenceNumber);
                        sqlCommand.Parameters.AddWithValue("@val07", ei_detail.Amount);
                        
                        sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.Write("SQLServer Ins Ei_Ome Exception : " + ex.Message);
                        actionResult = "FAIL";
                        break;
                    }
                    finally
                    {
                        if (actionResult == "SUCCESS")
                        {
                            insertedEi_DetailObjects.Add(ei_detail);
                        }
                    }
                }
            }
            return insertedEi_DetailObjects;
        }
    }
}
