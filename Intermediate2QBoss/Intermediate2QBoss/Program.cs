using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Intermediate2QBoss
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectStringPool projectStringPool = new ProjectStringPool();

            SQLServerConductor sqlServerConductor = new SQLServerConductor();
            QbossSQLServerConductor qbossSQLServerConductor = new QbossSQLServerConductor();
            OracleDBConductor oracleDBConductor = new OracleDBConductor();
            DataTable dataTable;
            DataTable dataTablepart;

            SqlEi_MasterObject sqlEi_MasterObject;
            SqlEi_DetailObject sqlEi_DetailObject;

            List<SqlEi_MasterObject> goodSQLServerEi_MasterObjects;
            List<SqlEi_MasterObject> insertedEi_MasterObjects;

            List<SqlEi_MasterObject> goodSQLServerMasterIDObj;
            List<SqlEi_MasterObject> updatedSQLServerMasterMacNumObj;

            List<SqlEi_DetailObject> goodSQLServerEi_DetailObjects;
            List<SqlEi_DetailObject> insertedEi_DetailObjects;

            string actionResult;
            string oraResult;
            int dataCount;
            string MasterResult;

            Random rnd = new Random();
            insertedEi_MasterObjects = new List<SqlEi_MasterObject>();

            goodSQLServerMasterIDObj = new List<SqlEi_MasterObject>();
            try
            {
                string sqlString = projectStringPool.getSelectEi_OmeDataSQL();
                string sqlpartString = projectStringPool.getselectOmeDataSQL();
                dataTable = sqlServerConductor.GetDataTable(sqlString);
                dataTablepart = oracleDBConductor.GetDataTable(sqlpartString);
                actionResult = "";

                goodSQLServerEi_MasterObjects = new List<SqlEi_MasterObject>();
                sqlEi_MasterObject = new SqlEi_MasterObject();
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {

                        actionResult = "Y";

                        try
                        {

                            sqlEi_MasterObject.InvoiceNumber = row[dataTable.Columns["ei_ome01"]].ToString();
                            sqlEi_MasterObject.Status = 1;
                            sqlEi_MasterObject.Purpose = 0;
                            sqlEi_MasterObject.InvoiceDate = (row[dataTable.Columns["ei_ome02"]]) == DBNull.Value ? "" :
                                Convert.ToDateTime(row[dataTable.Columns["ei_ome02"]]).ToString("yyyy-MM-dd");
                            sqlEi_MasterObject.CustomerID = row[dataTable.Columns["ei_ome04"]].ToString();
                            sqlEi_MasterObject.CustomerName = row[dataTable.Columns["ei_ome06"]].ToString();
                            sqlEi_MasterObject.CustomerTaxID = row[dataTable.Columns["ei_ome05"]].ToString();
                            sqlEi_MasterObject.InvoiceType = 7;
                            sqlEi_MasterObject.PrintMark = ' ';
                            sqlEi_MasterObject.RandomNumber = rnd.Next(0, 10000); // creates a number between 1 and 9999
                            sqlEi_MasterObject.CarrierType = "  ";
                            sqlEi_MasterObject.CarrierID = "  ";     
                            sqlEi_MasterObject.TaxType = ' ';
                            sqlEi_MasterObject.TaxRate = (row[dataTable.Columns["ei_ome10"]]) == DBNull.Value ? 0 :
                                    Convert.ToDecimal(row[dataTable.Columns["ei_ome10"]]);
                            sqlEi_MasterObject.TotalAmount = (row[dataTable.Columns["ei_ome13"]]) == DBNull.Value ? 0 :
                                    Convert.ToDecimal(row[dataTable.Columns["ei_ome13"]]);
                            sqlEi_MasterObject.DonateNo = "  ";
                            sqlEi_MasterObject.DonateMark = 0;
                            sqlEi_MasterObject.Exported = 0;
                            sqlEi_MasterObject.GroupMark = 0;
                            sqlEi_MasterObject.MachineCode = "DC";
                            sqlEi_MasterObject.MachineSerialNum = ' ';
                            sqlEi_MasterObject.InErrorList = 0;
                            sqlEi_MasterObject.UploadStatus = 0;
                            sqlEi_MasterObject.UploadMessage = "  ";
                            sqlEi_MasterObject.IOType = "O";
                            sqlEi_MasterObject.RejectReason = "  ";
                            sqlEi_MasterObject.RejectTime = " ";
                            sqlEi_MasterObject.CreditCard = 0;
                            sqlEi_MasterObject.Cash = 0;
                            sqlEi_MasterObject.CashDiscount = 0;
                            sqlEi_MasterObject.InvoiceSpecies = 2;
                            sqlEi_MasterObject.InvType = 35;
                            sqlEi_MasterObject.OrderNo = "  ";
                            sqlEi_MasterObject.CreditCardLast4No = "  ";
                            sqlEi_MasterObject.CustomerAddress = row[dataTable.Columns["ei_ome07"]].ToString();
                            sqlEi_MasterObject.MessageBeginTime = " ";
                            sqlEi_MasterObject.WebPrintState = "  ";
                            sqlEi_MasterObject.VAT = 0;

                        }
                        catch (Exception ex)
                        {
                            actionResult = "N";
                            Console.WriteLine("Foreach Exception:" + ex.Message);
                            PostalService postalService = new PostalService();
                            postalService.SendMail("levi.huang@aupa.com.tw", "Intermediate2QBoss Data Copier Alert", ex.Message);
                            break;
                        }     
                    }//End of if else
                }

                if (dataTablepart.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTablepart.Rows)
                    {
                        actionResult = "Y";
                        try
                        {
                            sqlEi_MasterObject.SalesAmount = (row[dataTablepart.Columns["ome59t"]]) == DBNull.Value ? 0 :
                                    Convert.ToInt32(row[dataTablepart.Columns["ome59t"]]);
                            sqlEi_MasterObject.FreeTaxSalesAmount = (row[dataTablepart.Columns["ome59"]]) == DBNull.Value ? 0 :
                                    Convert.ToInt32(row[dataTablepart.Columns["ome59"]]);
                            sqlEi_MasterObject.ZeroTaxSalesAmount = (row[dataTablepart.Columns["ome59t"]]) == DBNull.Value ? 0 :
                                    Convert.ToInt32(row[dataTablepart.Columns["ome59t"]]);
                            sqlEi_MasterObject.TaxAmount = (row[dataTablepart.Columns["ome59x"]]) == DBNull.Value ? 0 :
                                    Convert.ToInt32(row[dataTablepart.Columns["ome59x"]]);
                            sqlEi_MasterObject.SellerTaxID = row[dataTablepart.Columns["ome60"]].ToString();
                            sqlEi_MasterObject.SellerName = "歐帕生技醫藥股份有限公司 AUPA BIOPHARM CO.";
                            sqlEi_MasterObject.SellerAddress = "NULL";
                            sqlEi_MasterObject.CancelExported = ' ' ;
                            sqlEi_MasterObject.CancelReason = row[dataTablepart.Columns["omevoid2"]].ToString();
                            sqlEi_MasterObject.CancelTime = (row[dataTablepart.Columns["omevoidd"]]) == DBNull.Value ? "" :
                                Convert.ToDateTime(row[dataTablepart.Columns["omevoidd"]]).ToString("yyyy-MM-dd");
                            sqlEi_MasterObject.Notes = " ";
                            sqlEi_MasterObject.VoidExported = ' ';
                            sqlEi_MasterObject.VoidReason = row[dataTablepart.Columns["omecnclm"]].ToString();
                            sqlEi_MasterObject.VoidTime = (row[dataTablepart.Columns["omecnclt"]]) == DBNull.Value ? "" :
                                Convert.ToDateTime(row[dataTablepart.Columns["omecnclt"]]).ToString("yyyy-MM-dd");
                            sqlEi_MasterObject.CustomsClearanceMark = (row[dataTablepart.Columns["ome172"]]) == DBNull.Value ? 0 :
                                    Convert.ToInt16(row[dataTablepart.Columns["ome172"]]);
                        }
                        catch (Exception ex)
                        {
                            actionResult = "N";
                            Console.WriteLine("Foreach Exception:" + ex.Message);
                            PostalService postalService = new PostalService();
                            postalService.SendMail("levi.huang@aupa.com.tw", "Intermediate2QBoss Data Copier Alert", ex.Message);
                            break;
                        }
                    }
                }
                goodSQLServerEi_MasterObjects.Add(sqlEi_MasterObject);
                if (goodSQLServerEi_MasterObjects.Count > 0)
                {
                    foreach (SqlEi_MasterObject ei_InsMaster in goodSQLServerEi_MasterObjects)
                    {
                        actionResult = qbossSQLServerConductor.InsertEi_MasterSQLServer(ei_InsMaster);
                        if (actionResult == "SUCCESS")
                        {
                            insertedEi_MasterObjects.Add(ei_InsMaster);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception : " + ex.Message);
                return;
            }


            //EInvoiceMaster_MachineSerialNum Begin .
            if (insertedEi_MasterObjects.Count > 0)
            {
                // update EInvoiceMaster_MachineSerialNum
                try
                {
                    string SqlString = projectStringPool.getSelectMasterDataSQL();

                    dataTable = qbossSQLServerConductor.GetDataTable(SqlString);
                    actionResult = "";

                    updatedSQLServerMasterMacNumObj = new List<SqlEi_MasterObject>();
                    //goodSQLServerMasterMacNumObj = new List<SqlEi_MasterObject>();

                    if (dataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            sqlEi_MasterObject = new SqlEi_MasterObject();
                            actionResult = "Y";
                            try
                            {
                                sqlEi_MasterObject.Id = (row[dataTable.Columns["Id"]]) == DBNull.Value ? 0 :
                                       Convert.ToInt16(row[dataTable.Columns["Id"]]);
                                sqlEi_MasterObject.MachineSerialNum = (row[dataTable.Columns["Id"]]) == DBNull.Value ? 0 :
                                       Convert.ToInt16(row[dataTable.Columns["Id"]]);

                            }
                            catch (Exception ex)
                            {
                                actionResult = "N";
                                Console.WriteLine("Foreach Exception:" + ex.Message);
                                PostalService postalService = new PostalService();
                                postalService.SendMail("levi.huang@aupa.com.tw", "Intermediate2Qboss Data Copier Alert", ex.Message);
                                break;
                            }
                            finally
                            {
                                if (actionResult == "Y")
                                {
                                    SQLServerDataSecuricor dataSecuricor = new SQLServerDataSecuricor();
                                    dataCount = 0;
                                    dataCount = dataSecuricor.SelectEi_MasterMacNumRowCounts(sqlEi_MasterObject.MachineSerialNum);

                                    if (dataCount == 0)  //MachineSerialNum 跟 ID 不相同時
                                    {
                                        goodSQLServerMasterIDObj.Add(sqlEi_MasterObject);
                                    }
                                }
                            }//End of try-catch-finally
                             //}//End of foreach
                        }//End of if else
                        actionResult = "FAILED";

                        updatedSQLServerMasterMacNumObj = new List<SqlEi_MasterObject>();

                        if (goodSQLServerMasterIDObj.Count > 0)
                        {
                            foreach (SqlEi_MasterObject ei_UpdNum in goodSQLServerMasterIDObj)
                            {
                                qbossSQLServerConductor = new QbossSQLServerConductor();
                                actionResult = qbossSQLServerConductor.UpdateEi_MasterMacNumSQLServer(ei_UpdNum);
                                if (actionResult == "SUCCESS")
                                {
                                    updatedSQLServerMasterMacNumObj.Add(ei_UpdNum);
                                }
                            }
                        }
                        dataCount = 0;
                        dataCount = updatedSQLServerMasterMacNumObj.Count;
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Exception : " + ex.Message);
                    return;
                }
            }
           

            // insert MasterDetail
            try
            {
                string oraSQLString = projectStringPool.getSelectDetailTc_OmeDataSQL();

                dataTable = oracleDBConductor.GetDataTable(oraSQLString);
                oraResult = "";

                //insertSQLServerEi_DetailObjects = new List<OraEi_DetailObject>();
                goodSQLServerEi_DetailObjects = new List<SqlEi_DetailObject>();

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        sqlEi_DetailObject = new SqlEi_DetailObject();
                        oraResult = "Y";

                        try
                        {
                            sqlEi_DetailObject.InvoiceId = ' ';
                            sqlEi_DetailObject.ProductID = row[dataTable.Columns["omb04"]].ToString();
                            sqlEi_DetailObject.Description = row[dataTable.Columns["omb06"]].ToString();
                            sqlEi_DetailObject.Quantity = (row[dataTable.Columns["omb12"]]) == DBNull.Value ? 0 :
                                   Convert.ToDecimal(row[dataTable.Columns["omb12"]]);
                            sqlEi_DetailObject.Unit = row[dataTable.Columns["omb05"]].ToString();
                            sqlEi_DetailObject.UnitPrice = (row[dataTable.Columns["omb17"]]) == DBNull.Value ? 0 :
                                   Convert.ToDecimal(row[dataTable.Columns["omb17"]]);
                            sqlEi_DetailObject.SequenceNumber = (row[dataTable.Columns["omb03"]]) == DBNull.Value ? 0 :
                                   Convert.ToInt16(row[dataTable.Columns["omb03"]]);
                            sqlEi_DetailObject.Amount = (row[dataTable.Columns["omb18t"]]) == DBNull.Value ? 0 :
                                   Convert.ToDecimal(row[dataTable.Columns["omb18t"]]);
                        }
                        catch (Exception ex)
                        {
                            oraResult = "N";
                            Console.WriteLine("Foreach Exception:" + ex.Message);
                            PostalService postalService = new PostalService();
                            postalService.SendMail("levi.huang@aupa.com.tw", "Intermediate2Qboss Data Copier Alert", ex.Message);
                            break;
                        }
                        finally
                        {
                            if (oraResult == "Y")
                            {
                                SQLServerDataSecuricor dataSecuricor = new SQLServerDataSecuricor();
                                dataCount = 0;
                                dataCount = dataSecuricor.SelectEi_DetailRowCounts(sqlEi_DetailObject.ProductID);

                                if (dataCount == 0)
                                {
                                    goodSQLServerEi_DetailObjects.Add(sqlEi_DetailObject);
                                }
                            }
                        }//End of try-catch-finally
                        //}//End of foreach
                    }//End of if else
                    MasterResult = "FAILED";
                    insertedEi_DetailObjects = new List<SqlEi_DetailObject>();

                    if (goodSQLServerEi_DetailObjects.Count > 0)
                    {
                        foreach (SqlEi_DetailObject ei_InsDetail in goodSQLServerEi_DetailObjects)
                        {
                            qbossSQLServerConductor = new QbossSQLServerConductor();
                            MasterResult = qbossSQLServerConductor.InsertEi_DetailSQLServer(ei_InsDetail);
                            if (MasterResult == "SUCCESS")
                            {
                                insertedEi_DetailObjects.Add(ei_InsDetail);
                            }
                        }

                        foreach (SqlEi_MasterObject ei_UpdDetailId in goodSQLServerMasterIDObj)
                        {
                            qbossSQLServerConductor.UpdateEi_DetailInvIdSQLServer(ei_UpdDetailId);
                            
                        }
                    }
                    dataCount = 0;
                    dataCount = insertedEi_DetailObjects.Count;
                }

            }
            catch (Exception ex)
            {
                Console.Write("Exception : " + ex.Message);
                return;
            }
        }
    }
}
