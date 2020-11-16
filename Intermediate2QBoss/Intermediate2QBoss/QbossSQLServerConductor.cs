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

        public String InsertEi_MasterSQLServer(SqlEi_MasterObject sqlEi_Masters)
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

                sqlCommand.Parameters.AddWithValue("@val02", sqlEi_Masters.InvoiceNumber);
                sqlCommand.Parameters.AddWithValue("@val03", sqlEi_Masters.Status);
                sqlCommand.Parameters.AddWithValue("@val04", sqlEi_Masters.Purpose);
                sqlCommand.Parameters.AddWithValue("@val05", sqlEi_Masters.InvoiceDate);
                sqlCommand.Parameters.AddWithValue("@val06", sqlEi_Masters.CustomerID);
                sqlCommand.Parameters.AddWithValue("@val07", sqlEi_Masters.CustomerName);
                sqlCommand.Parameters.AddWithValue("@val08", sqlEi_Masters.CustomerTaxID);
                sqlCommand.Parameters.AddWithValue("@val09", sqlEi_Masters.InvoiceType);
                sqlCommand.Parameters.AddWithValue("@val010", sqlEi_Masters.PrintMark);
                sqlCommand.Parameters.AddWithValue("@val011", sqlEi_Masters.RandomNumber);
                sqlCommand.Parameters.AddWithValue("@val012", sqlEi_Masters.CarrierType);
                sqlCommand.Parameters.AddWithValue("@val013", sqlEi_Masters.CarrierID);
                sqlCommand.Parameters.AddWithValue("@val014", sqlEi_Masters.SalesAmount);
                sqlCommand.Parameters.AddWithValue("@val015", sqlEi_Masters.FreeTaxSalesAmount);
                sqlCommand.Parameters.AddWithValue("@val016", sqlEi_Masters.ZeroTaxSalesAmount);
                sqlCommand.Parameters.AddWithValue("@val017", sqlEi_Masters.TaxAmount);
                sqlCommand.Parameters.AddWithValue("@val018", sqlEi_Masters.TaxType);
                sqlCommand.Parameters.AddWithValue("@val019", sqlEi_Masters.TaxRate);
                sqlCommand.Parameters.AddWithValue("@val020", sqlEi_Masters.TotalAmount);
                sqlCommand.Parameters.AddWithValue("@val021", sqlEi_Masters.DonateNo);
                sqlCommand.Parameters.AddWithValue("@val022", sqlEi_Masters.DonateMark);
                sqlCommand.Parameters.AddWithValue("@val023", sqlEi_Masters.Exported);
                sqlCommand.Parameters.AddWithValue("@val024", sqlEi_Masters.GroupMark);
                sqlCommand.Parameters.AddWithValue("@val025", sqlEi_Masters.SellerTaxID);
                sqlCommand.Parameters.AddWithValue("@val026", sqlEi_Masters.SellerName);
                sqlCommand.Parameters.AddWithValue("@val027", sqlEi_Masters.SellerAddress);
                sqlCommand.Parameters.AddWithValue("@val028", sqlEi_Masters.MachineCode);
                sqlCommand.Parameters.AddWithValue("@val029", sqlEi_Masters.MachineSerialNum);
                sqlCommand.Parameters.AddWithValue("@val030", sqlEi_Masters.CancelExported);
                sqlCommand.Parameters.AddWithValue("@val031", sqlEi_Masters.CancelReason);
                sqlCommand.Parameters.AddWithValue("@val032", sqlEi_Masters.CancelTime);
                sqlCommand.Parameters.AddWithValue("@val033", sqlEi_Masters.Notes);
                sqlCommand.Parameters.AddWithValue("@val034", sqlEi_Masters.VoidExported);
                sqlCommand.Parameters.AddWithValue("@val035", sqlEi_Masters.VoidReason);
                sqlCommand.Parameters.AddWithValue("@val036", sqlEi_Masters.VoidTime);
                sqlCommand.Parameters.AddWithValue("@val037", sqlEi_Masters.InErrorList);
                sqlCommand.Parameters.AddWithValue("@val038", sqlEi_Masters.UploadStatus);
                sqlCommand.Parameters.AddWithValue("@val039", sqlEi_Masters.UploadMessage);
                sqlCommand.Parameters.AddWithValue("@val040", sqlEi_Masters.IOType);
                sqlCommand.Parameters.AddWithValue("@val041", sqlEi_Masters.RejectReason);
                sqlCommand.Parameters.AddWithValue("@val042", sqlEi_Masters.RejectTime);
                sqlCommand.Parameters.AddWithValue("@val043", sqlEi_Masters.CreditCard);
                sqlCommand.Parameters.AddWithValue("@val044", sqlEi_Masters.Cash);
                sqlCommand.Parameters.AddWithValue("@val045", sqlEi_Masters.CashDiscount);
                sqlCommand.Parameters.AddWithValue("@val046", sqlEi_Masters.InvoiceSpecies);
                sqlCommand.Parameters.AddWithValue("@val047", sqlEi_Masters.InvType);
                sqlCommand.Parameters.AddWithValue("@val048", sqlEi_Masters.OrderNo);
                sqlCommand.Parameters.AddWithValue("@val049", sqlEi_Masters.CustomsClearanceMark);
                sqlCommand.Parameters.AddWithValue("@val050", sqlEi_Masters.CreditCardLast4No);
                sqlCommand.Parameters.AddWithValue("@val051", sqlEi_Masters.CustomerAddress);
                sqlCommand.Parameters.AddWithValue("@val052", sqlEi_Masters.MessageBeginTime);
                sqlCommand.Parameters.AddWithValue("@val053", sqlEi_Masters.WebPrintState);
                sqlCommand.Parameters.AddWithValue("@val054", sqlEi_Masters.VAT);

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

                SqlCommand sqlcommand = new SqlCommand(sql, this.sqlConnection);
                sqlcommand.Connection = sqlConnection;
                sqlcommand.CommandText = sql;
                sqlcommand.CommandType = CommandType.Text;

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

        public String InsertEi_DetailSQLServer(SqlEi_DetailObject sqlEi_Details)
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

                sqlCommand.Parameters.AddWithValue("@val00", sqlEi_Details.InvoiceId);
                sqlCommand.Parameters.AddWithValue("@val01", sqlEi_Details.ProductID);
                sqlCommand.Parameters.AddWithValue("@val02", sqlEi_Details.Description);
                sqlCommand.Parameters.AddWithValue("@val03", sqlEi_Details.Quantity);
                sqlCommand.Parameters.AddWithValue("@val04", sqlEi_Details.Unit);
                sqlCommand.Parameters.AddWithValue("@val05", sqlEi_Details.UnitPrice);
                sqlCommand.Parameters.AddWithValue("@val06", sqlEi_Details.SequenceNumber);
                sqlCommand.Parameters.AddWithValue("@val07", sqlEi_Details.Amount);

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

        public String UpdateEi_MasterMacNumSQLServer(SqlEi_MasterObject sqlEi_MasObjs)
        {
            sql = " update  EInvoiceMaster set MachineSerialNum = @val00  " +
                " where InvoiceNumber = @val01";

            actionResult = "SUCCESS";
            OpenConnection();

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sql;

                sqlCommand.Parameters.AddWithValue("@val00", sqlEi_MasObjs.Id);
                sqlCommand.Parameters.AddWithValue("@val01", sqlEi_MasObjs.InvoiceNumber);


                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write("SQLServer Ins Ei_MasterMacNum Exception : " + ex.Message);
                actionResult = "FAIL";

            }
            finally
            {
                CloseConnection();
            }


            return actionResult;
        }

        public String UpdateEi_DetailInvIdSQLServer(string Key1, string Key2, string Key3 ,string key4 ,string key5)
        {
            sql = " update  EInvoiceDetail set ProductID = ' " + Key1 + "'" +
                " , Description = '"  + Key2  + "'" +
                " , Quantity ='" + Key3 + "'" +
                " , Unit ='" + key4 + "'" +
                " , SequenceNumber = '" + key5 + "'" +
                " where InvoiceId = '" + Key3 + "'";
                


            actionResult = "SUCCESS";
            OpenConnection();

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = sql;
                sqlCommand.CommandType = CommandType.Text;



                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write("SQLServer Ins Ei_DetailId Exception : " + ex.Message);
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
