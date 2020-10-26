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
            MasterDetailIDSQLServerConductor masterDetailIDSQLServerConductor = new MasterDetailIDSQLServerConductor();

            DataTable dataTable;

            OraEi_MasterObject oraEi_MasterObject;
            OraEi_DetailObject oraEi_DetailObject;
            OraEi_DetailObject oraEi_DetailIDObj;

            List<OraEi_MasterObject> goodSQLServerEi_MasterObjects;
            List<OraEi_MasterObject> insertedEi_MasterObjects;

            List<OraEi_DetailObject> goodSQLServerEi_DetailObjects;
            List<OraEi_DetailObject> insertedEi_DetailObjects;

            List<OraEi_DetailObject> updateSQLServerDetailId;
            List<OraEi_DetailObject> goodSQLServerEi_DetailIdObj;
            List<OraEi_DetailObject> updatedSQLServerDetailIdObj;

            string actionResult;
            string oraResult;
            int dataCount;
            string MasterResult;

            Random rnd = new Random();

            try
            {
                string sqlString = projectStringPool.getSelectEi_OmeDataSQL();

                dataTable = sqlServerConductor.GetDataTable(sqlString);
                actionResult = "";

                //insertSQLServerEi_MasterObjects = new List<OraEi_MasterObject>();
                goodSQLServerEi_MasterObjects = new List<OraEi_MasterObject>();

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        oraEi_MasterObject = new OraEi_MasterObject();
                        actionResult = "Y";

                        try
                        {

                            oraEi_MasterObject.InvoiceNumber = row[dataTable.Columns["ei_ome01"]].ToString();
                            oraEi_MasterObject.Status = 1;
                            oraEi_MasterObject.Purpose = 0;
                            oraEi_MasterObject.InvoiceDate = (row[dataTable.Columns["ei_ome02"]]) == DBNull.Value ? "" :
                                Convert.ToDateTime(row[dataTable.Columns["ei_ome02"]]).ToString("yyyy-MM-dd");
                            oraEi_MasterObject.CustomerID = row[dataTable.Columns["ei_ome04"]].ToString();
                            oraEi_MasterObject.CustomerName = row[dataTable.Columns["ei_ome06"]].ToString();
                            oraEi_MasterObject.CustomerTaxID = row[dataTable.Columns["ei_ome05"]].ToString();
                            oraEi_MasterObject.InvoiceType = 7;
                            oraEi_MasterObject.PrintMark = ' ';
                            oraEi_MasterObject.RandomNumber = rnd.Next(0, 10000); // creates a number between 1 and 9999
                            oraEi_MasterObject.CarrierType = "  ";
                            oraEi_MasterObject.CarrierID = "  ";
                            oraEi_MasterObject.SalesAmount = (row[dataTable.Columns["ei_ome13"]]) == DBNull.Value ? 0 :
                                    Convert.ToDecimal(row[dataTable.Columns["ei_ome13"]]);
                            oraEi_MasterObject.FreeTaxSalesAmount = (row[dataTable.Columns["ei_ome11"]]) == DBNull.Value ? 0 :
                                    Convert.ToDecimal(row[dataTable.Columns["ei_ome11"]]);
                            oraEi_MasterObject.ZeroTaxSalesAmount = (row[dataTable.Columns["ei_ome11"]]) == DBNull.Value ? 0 :
                                    Convert.ToDecimal(row[dataTable.Columns["ei_ome11"]]);
                            oraEi_MasterObject.TaxAmount = (row[dataTable.Columns["ei_ome12"]]) == DBNull.Value ? 0 :
                                    Convert.ToDecimal(row[dataTable.Columns["ei_ome12"]]);
                            oraEi_MasterObject.TaxRate = (row[dataTable.Columns["ei_ome10"]]) == DBNull.Value ? 0 :
                                    Convert.ToDecimal(row[dataTable.Columns["ei_ome10"]]);
                            oraEi_MasterObject.TotalAmount = (row[dataTable.Columns["ei_ome13"]]) == DBNull.Value ? 0 :
                                    Convert.ToDecimal(row[dataTable.Columns["ei_ome13"]]);
                            oraEi_MasterObject.DonateNo = "  ";
                            oraEi_MasterObject.DonateMark = 0;
                            oraEi_MasterObject.Exported = 0;
                            oraEi_MasterObject.GroupMark = 0;
                            oraEi_MasterObject.SellerTaxID = "53096433";
                            oraEi_MasterObject.SellerName = "歐帕生技醫藥股份有限公司 AUPA BIOPHARM CO.";
                            oraEi_MasterObject.SellerAddress = "NULL";
                            oraEi_MasterObject.MachineCode = "DC";
                            oraEi_MasterObject.MachineSerialNum = 1;
                            oraEi_MasterObject.CancelExported = ' ';
                            oraEi_MasterObject.CancelReason = "  ";
                            oraEi_MasterObject.CancelTime = " ";
                            oraEi_MasterObject.Notes = " ";
                            oraEi_MasterObject.VoidExported = ' ';
                            oraEi_MasterObject.VoidReason = "  ";
                            oraEi_MasterObject.VoidTime = " ";
                            oraEi_MasterObject.InErrorList = 0;
                            oraEi_MasterObject.UploadStatus = 0;
                            oraEi_MasterObject.UploadMessage = "  ";
                            oraEi_MasterObject.IOType = "O";
                            oraEi_MasterObject.RejectReason = "  ";
                            oraEi_MasterObject.RejectTime = " ";
                            oraEi_MasterObject.CreditCard = 0;
                            oraEi_MasterObject.Cash = 0;
                            oraEi_MasterObject.CashDiscount = 0;
                            oraEi_MasterObject.InvoiceSpecies = 2;
                            oraEi_MasterObject.InvType = 35;
                            oraEi_MasterObject.OrderNo = "  ";
                            oraEi_MasterObject.CustomsClearanceMark = ' ';
                            oraEi_MasterObject.CreditCardLast4No = "  ";
                            oraEi_MasterObject.CustomerAddress = "  ";
                            oraEi_MasterObject.MessageBeginTime = " ";
                            oraEi_MasterObject.WebPrintState = "  ";
                            oraEi_MasterObject.VAT = 0;


                        }
                        catch (Exception ex)
                        {
                            actionResult = "N";
                            Console.WriteLine("Foreach Exception:" + ex.Message);
                            PostalService postalService = new PostalService();
                            postalService.SendMail("levi.huang@aupa.com.tw", "Intermediate Data Copier Alert", ex.Message);
                            break;
                        }
                        finally
                        {
                            if (actionResult == "Y")
                            {
                                SQLServerDataSecuricor dataSecuricor = new SQLServerDataSecuricor();
                                dataCount = 0;
                                dataCount = dataSecuricor.SelectEi_MasterRowCounts(oraEi_MasterObject.InvoiceNumber);

                                if (dataCount == 0)
                                {
                                    goodSQLServerEi_MasterObjects.Add(oraEi_MasterObject);
                                }
                            }
                        }//End of try-catch-finally
                    }//End of if else
                    MasterResult = "FAILED";

                    insertedEi_MasterObjects = new List<OraEi_MasterObject>();

                    if (goodSQLServerEi_MasterObjects.Count > 0)
                    {
                        foreach (OraEi_MasterObject ei_InsMaster in goodSQLServerEi_MasterObjects)
                        {
                            qbossSQLServerConductor = new QbossSQLServerConductor();
                            MasterResult = qbossSQLServerConductor.InsertEi_MasterSQLServer(ei_InsMaster);
                            if (MasterResult == "SUCCESS")
                            {
                                insertedEi_MasterObjects.Add(ei_InsMaster);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write("Exception : " + ex.Message);
                return;
            }


            // insert MasterDetail
            try
            {
                string oraSQLString = projectStringPool.getSelectDetailTc_OmeDataSQL();

                dataTable = oracleDBConductor.GetDataTable(oraSQLString);
                oraResult = "";

                //insertSQLServerEi_DetailObjects = new List<OraEi_DetailObject>();
                goodSQLServerEi_DetailObjects = new List<OraEi_DetailObject>();

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        oraEi_DetailObject = new OraEi_DetailObject();
                        oraResult = "Y";

                        try
                        {
                            oraEi_DetailObject.InvoiceId = ' ';
                            oraEi_DetailObject.ProductID = row[dataTable.Columns["omb04"]].ToString();
                            oraEi_DetailObject.Description = row[dataTable.Columns["omb06"]].ToString();
                            oraEi_DetailObject.Quantity = (row[dataTable.Columns["omb12"]]) == DBNull.Value ? 0 :
                                   Convert.ToDecimal(row[dataTable.Columns["omb12"]]);
                            oraEi_DetailObject.Unit = row[dataTable.Columns["omb05"]].ToString();
                            oraEi_DetailObject.UnitPrice = (row[dataTable.Columns["omb17"]]) == DBNull.Value ? 0 :
                                   Convert.ToDecimal(row[dataTable.Columns["omb17"]]);
                            oraEi_DetailObject.SequenceNumber = (row[dataTable.Columns["omb03"]]) == DBNull.Value ? 0 :
                                   Convert.ToInt16(row[dataTable.Columns["omb03"]]);
                            oraEi_DetailObject.Amount = (row[dataTable.Columns["omb18t"]]) == DBNull.Value ? 0 :
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
                                dataCount = dataSecuricor.SelectEi_DetailRowCounts(oraEi_DetailObject.ProductID);

                                if (dataCount == 0)
                                {
                                    goodSQLServerEi_DetailObjects.Add(oraEi_DetailObject);
                                }
                            }
                        }//End of try-catch-finally
                        //}//End of foreach
                    }//End of if else
                    MasterResult = "FAILED";
                    
                    insertedEi_DetailObjects = new List<OraEi_DetailObject>();

                    if (goodSQLServerEi_DetailObjects.Count > 0)
                    {
                        foreach (OraEi_DetailObject ei_InsDetail in goodSQLServerEi_DetailObjects)
                        {
                            qbossSQLServerConductor = new QbossSQLServerConductor();
                            MasterResult = qbossSQLServerConductor.InsertEi_DetailSQLServer(ei_InsDetail);
                            if (MasterResult == "SUCCESS")
                            {
                                insertedEi_DetailObjects.Add(ei_InsDetail);
                            }
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

            // update MasterDetail_InvoiceId
            try
            {
                string oraSQLString = projectStringPool.getSelectDetailMasterDataSQL();

                dataTable = masterDetailIDSQLServerConductor.GetDataTable(oraSQLString);
                oraResult = "";

                updateSQLServerDetailId =new List<OraEi_DetailObject>();
                goodSQLServerEi_DetailIdObj = new List<OraEi_DetailObject>();

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        oraEi_DetailIDObj = new OraEi_DetailObject();
                        oraResult = "Y";

                        try
                        {
                            oraEi_DetailIDObj.InvoiceId = (row[dataTable.Columns["Id"]]) == DBNull.Value ? 0 :
                                   Convert.ToInt16(row[dataTable.Columns["Id"]]);


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
                                dataCount = dataSecuricor.SelectEi_MasterIDRowCounts(oraEi_DetailIDObj.InvoiceId);

                                if (dataCount == 1)
                                {
                                    goodSQLServerEi_DetailIdObj.Add(oraEi_DetailIDObj);
                                }
                            }
                        }//End of try-catch-finally
                        //}//End of foreach
                    }//End of if else
                    MasterResult = "FAILED";

                    updatedSQLServerDetailIdObj = new List<OraEi_DetailObject>();

                    if (goodSQLServerEi_DetailIdObj.Count > 0)
                    {
                        foreach (OraEi_DetailObject ei_InsDetailId in goodSQLServerEi_DetailIdObj)
                        {
                            masterDetailIDSQLServerConductor = new MasterDetailIDSQLServerConductor();
                            MasterResult = masterDetailIDSQLServerConductor.UpdateEi_DetailInvIdSQLServer(ei_InsDetailId);
                            if (MasterResult == "SUCCESS")
                            {
                                updatedSQLServerDetailIdObj.Add(ei_InsDetailId);
                            }
                        }

                    }

                    dataCount = 0;
                    dataCount = updatedSQLServerDetailIdObj.Count;

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
