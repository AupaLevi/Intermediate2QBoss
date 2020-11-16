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
            DataTable OraTable;
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

            goodSQLServerMasterIDObj = new List<SqlEi_MasterObject>();
            goodSQLServerEi_DetailObjects = new List<SqlEi_DetailObject>();
            sqlEi_DetailObject = new SqlEi_DetailObject();

            try
            {
                string sqlString = projectStringPool.getselectOmeDataSQL();
                dataTable = oracleDBConductor.GetDataTable(sqlString);
                actionResult = "";
                goodSQLServerEi_MasterObjects = new List<SqlEi_MasterObject>();

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        sqlEi_MasterObject = new SqlEi_MasterObject();
                        actionResult = "Y";
                        try
                        {
                            sqlEi_MasterObject.InvoiceNumber = row[dataTable.Columns["ome01"]].ToString();
                            sqlEi_MasterObject.Status = 1;
                            sqlEi_MasterObject.Purpose = 0;
                            sqlEi_MasterObject.InvoiceDate = (row[dataTable.Columns["ome02"]]) == DBNull.Value ? "" :
                                Convert.ToDateTime(row[dataTable.Columns["ome02"]]).ToString("yyyy-MM-dd");
                            sqlEi_MasterObject.CustomerID = row[dataTable.Columns["ome04"]].ToString();
                            sqlEi_MasterObject.CustomerName = row[dataTable.Columns["ome043"]].ToString();
                            sqlEi_MasterObject.CustomerTaxID = row[dataTable.Columns["ome042"]].ToString();
                            sqlEi_MasterObject.InvoiceType = 7;
                            sqlEi_MasterObject.PrintMark = ' ';
                            sqlEi_MasterObject.RandomNumber = rnd.Next(0, 10000); // creates a number between 1 and 9999
                            sqlEi_MasterObject.CarrierType = "  ";
                            sqlEi_MasterObject.CarrierID = "  ";
                            //sqlEi_MasterObject.TaxType = ' ';
                            sqlEi_MasterObject.TaxRate = (row[dataTable.Columns["ome211"]]) == DBNull.Value ? 0 :
                                    Convert.ToDecimal(row[dataTable.Columns["ome211"]]);
                            sqlEi_MasterObject.TotalAmount = (row[dataTable.Columns["ome59t"]]) == DBNull.Value ? 0 :
                                    Convert.ToInt32(row[dataTable.Columns["ome59t"]]);
                            sqlEi_MasterObject.DonateNo = "  ";
                            sqlEi_MasterObject.DonateMark = 0;
                            sqlEi_MasterObject.Exported = 0;
                            sqlEi_MasterObject.GroupMark = 0;
                            sqlEi_MasterObject.MachineCode = "DC";
                            //sqlEi_MasterObject.MachineSerialNum = ' ';
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
                            sqlEi_MasterObject.CustomerAddress = row[dataTable.Columns["ome044"]].ToString();
                            sqlEi_MasterObject.MessageBeginTime = " ";
                            sqlEi_MasterObject.WebPrintState = "  ";
                            sqlEi_MasterObject.VAT = 0;

                            sqlEi_MasterObject.SalesAmount = (row[dataTable.Columns["ome59t"]]) == DBNull.Value ? 0 :
                                   Convert.ToInt32(row[dataTable.Columns["ome59t"]]);
                            sqlEi_MasterObject.FreeTaxSalesAmount = (row[dataTable.Columns["ome59"]]) == DBNull.Value ? 0 :
                                    Convert.ToInt32(row[dataTable.Columns["ome59"]]);
                            sqlEi_MasterObject.ZeroTaxSalesAmount = (row[dataTable.Columns["ome59t"]]) == DBNull.Value ? 0 :
                                    Convert.ToInt32(row[dataTable.Columns["ome59t"]]);
                            sqlEi_MasterObject.TaxAmount = (row[dataTable.Columns["ome59x"]]) == DBNull.Value ? 0 :
                                    Convert.ToInt32(row[dataTable.Columns["ome59x"]]);
                            sqlEi_MasterObject.SellerTaxID = row[dataTable.Columns["ome60"]].ToString();
                            sqlEi_MasterObject.SellerName = "歐帕生技醫藥股份有限公司 AUPA BIOPHARM CO.";
                            sqlEi_MasterObject.SellerAddress = "NULL";
                            sqlEi_MasterObject.CancelExported = ' ';
                            sqlEi_MasterObject.CancelReason = row[dataTable.Columns["omevoid2"]].ToString();
                            sqlEi_MasterObject.CancelTime = (row[dataTable.Columns["omevoidd"]]) == DBNull.Value ? "" :
                                Convert.ToDateTime(row[dataTable.Columns["omevoidd"]]).ToString("yyyy-MM-dd");
                            sqlEi_MasterObject.Notes = " ";
                            sqlEi_MasterObject.VoidExported = ' ';
                            sqlEi_MasterObject.VoidReason = row[dataTable.Columns["omecnclm"]].ToString();
                            sqlEi_MasterObject.VoidTime = (row[dataTable.Columns["omecnclt"]]) == DBNull.Value ? "" :
                                Convert.ToDateTime(row[dataTable.Columns["omecnclt"]]).ToString("yyyy-MM-dd");
                            sqlEi_MasterObject.CustomsClearanceMark = (row[dataTable.Columns["ome172"]]) == DBNull.Value ? 0 :
                                    Convert.ToInt16(row[dataTable.Columns["ome172"]]);
                        }
                        catch (Exception ex)
                        {
                            actionResult = "N";
                            Console.WriteLine("Foreach Exception:" + ex.Message);
                            PostalService postalService = new PostalService();
                            postalService.SendMail("levi.huang@aupa.com.tw", "Intermediate2QBoss Data Copier Alert", ex.Message);
                            break;
                        }
                        finally
                        {
                            if (actionResult == "Y")
                            {
                                SQLServerDataSecuricor dataSecuricor = new SQLServerDataSecuricor();
                                dataCount = 0;
                                dataCount = dataSecuricor.SelectEi_MasterRowCounts(sqlEi_MasterObject.InvoiceNumber);
                                if (dataCount == 0)
                                {
                                    goodSQLServerEi_MasterObjects.Add(sqlEi_MasterObject);
                                }
                            }
                        }
                    }//End of if else
                }

                actionResult = "FAILED";
                insertedEi_MasterObjects = new List<SqlEi_MasterObject>();
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
                                sqlEi_MasterObject.InvoiceNumber = row[dataTable.Columns["InvoiceNumber"]].ToString();
                                sqlEi_MasterObject.TotalAmount = (row[dataTable.Columns["TotalAmount"]]) == DBNull.Value ? 0 :
                                   Convert.ToInt32(row[dataTable.Columns["TotalAmount"]]);
                                sqlEi_MasterObject.FreeTaxSalesAmount = (row[dataTable.Columns["FreeTaxSalesAmount"]]) == DBNull.Value ? 0 :
                                   Convert.ToInt32(row[dataTable.Columns["FreeTaxSalesAmount"]]);

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

            try
            {
                string SqlString = projectStringPool.getSelectMasterDataSQL();
                dataTable = qbossSQLServerConductor.GetDataTable(SqlString);
                actionResult = "";

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        sqlEi_DetailObject = new SqlEi_DetailObject();
                        actionResult = "Y";

                        try
                        {
                            sqlEi_DetailObject.InvoiceId = (row[dataTable.Columns["Id"]]) == DBNull.Value ? 0 :
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


                        // insert MasterDetail
                        try
                        {
                            string oraSQLString = projectStringPool.getSelectDetailTc_OmeDataSQL();
                            OraTable = oracleDBConductor.GetDataTable(oraSQLString);

                            oraResult = "";


                            if (dataTable.Rows.Count > 0)
                            {
                                foreach (DataRow rowpart in OraTable.Rows)
                                {
                                    //sqlEi_DetailObject = new SqlEi_DetailObject();
                                    oraResult = "Y";

                                    try
                                    {
                                        //sqlEi_DetailObject.InvoiceId =  (rowpart[OraTable.Columns["Id"]]) == DBNull.Value ? 0 :
                                            //Convert.ToInt16(row[dataTable.Columns["Id"]]);

                                        sqlEi_DetailObject.ProductID = rowpart[OraTable.Columns["omb04"]].ToString();
                                        sqlEi_DetailObject.Description = rowpart[OraTable.Columns["omb06"]].ToString();
                                        sqlEi_DetailObject.Quantity = (rowpart[OraTable.Columns["omb12"]]) == DBNull.Value ? 0 :
                                               Convert.ToDecimal(rowpart[OraTable.Columns["omb12"]]);
                                        sqlEi_DetailObject.Unit = rowpart[OraTable.Columns["omb05"]].ToString();
                                        sqlEi_DetailObject.UnitPrice = (rowpart[OraTable.Columns["omb17"]]) == DBNull.Value ? 0 :
                                               Convert.ToDecimal(rowpart[OraTable.Columns["omb17"]]);
                                        sqlEi_DetailObject.SequenceNumber = (rowpart[OraTable.Columns["omb03"]]) == DBNull.Value ? 0 :
                                               Convert.ToInt16(rowpart[OraTable.Columns["omb03"]]);
                                        sqlEi_DetailObject.Amount = (rowpart[OraTable.Columns["omb18t"]]) == DBNull.Value ? 0 :
                                               Convert.ToDecimal(rowpart[OraTable.Columns["omb18t"]]);
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
                                            dataCount = dataSecuricor.SelectEi_DetailRowCounts(sqlEi_DetailObject.InvoiceId, sqlEi_DetailObject.ProductID, sqlEi_DetailObject.Description, sqlEi_DetailObject.Quantity, sqlEi_DetailObject.Unit, sqlEi_DetailObject.UnitPrice, sqlEi_DetailObject.SequenceNumber, sqlEi_DetailObject.Amount);

                                            if (dataCount == 0)
                                            {
                                                goodSQLServerEi_DetailObjects.Add(sqlEi_DetailObject);

                                                if (goodSQLServerEi_DetailObjects.Count > 0)
                                                {
                                                    foreach (SqlEi_DetailObject ei_InsDetail in goodSQLServerEi_DetailObjects)
                                                    {
                                                        qbossSQLServerConductor = new QbossSQLServerConductor();
                                                        qbossSQLServerConductor.InsertEi_DetailSQLServer(ei_InsDetail);
                                                        sqlEi_DetailObject = new SqlEi_DetailObject();
                                                    }

                                                }
                                            }
                                        }
                                    }//End of try-catch-finally
                                     //}//End of foreach
                                }//End of if else

                               
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
            catch (Exception ex)
            {
                Console.Write("Exception : " + ex.Message);
                return;
            }

        }
    }
}
