using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate2QBoss
{
    class ProjectStringPool
    {
        //Oracle Side
        private string oracleConnectionString;

        

        //SQLServer Side
        private string selectEi_OmeDataSQL;
        private string insSQLServerEi_MasterSQL;

        private string SelectDetailTc_OmeDataSQL;
        private string insSQLServerEi_DetailSQL;

        public string getOracleConnectionString(string host, string port, string sid, string user, string pass)
        {
            this.oracleConnectionString = String.Format(
                "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
                "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
                host, port, sid, user, pass);
            return this.oracleConnectionString;
        }

        public string getSelectEi_OmeDataSQL()
        {
            this.selectEi_OmeDataSQL =
                " SELECT * FROM ei_ome_file ";

            return this.selectEi_OmeDataSQL;
        }

        public string getInsSQLServerEi_MasterSQL()
        {
            this.insSQLServerEi_MasterSQL =
                
                " INSERT INTO EInvoiceMaster (" +
                " InvoiceNumber ,Status ,Purpose ,InvoiceDate ,CustomerID ,CustomerName ,CustomerTaxID ,InvoiceType ,PrintMark ,RandomNumber ," +
                " CarrierType ,CarrierID ,SalesAmount ,FreeTaxSalesAmount ,ZeroTaxSalesAmount ,TaxAmount ,TaxType ,TaxRate ," +
                " TotalAmount ,DonateNo ,DonateMark ,Exported ,GroupMark ,SellerTaxID ,SellerName ,SellerAddress ,MachineCode ,MachineSerialNum ," +
                " CancelExported ,CancelReason ,CancelTime ," +
                " Notes ,VoidExported ,VoidReason ,VoidTime ,InErrorList ,UploadStatus ,UploadMessage ,IOType ,RejectReason ,RejectTime ,CreditCard ,Cash ," +
                " CashDiscount ,InvoiceSpecies ,InvType ,OrderNo ," +
                " CustomsClearanceMark ,CreditCardLast4No ,CustomerAddress ,MessageBeginTime ,WebPrintState ,VAT " +
                ")VALUES(" +
                " @val02 ,@val03 ,@val04 ,@val05 ,@val06 ,@val07 ,@val08 ,@val09 ,@val010 ,@val011 ,@val012 ,@val013 ,@val014 ,@val015 ," +
                "@val016 ,@val017 ,@val018 ,@val019 ,@val020 ,@val021 ,@val022 ,@val023 ,@val024 ,@val025 ,@val026 ,@val027 ,@val028 ,@val029 ," +
                "@val030 ,@val031 ,@val032 ,@val033 ,@val034 ,@val035 ,@val036 ,@val037 ,@val038 ,@val039 ,@val040 ,@val041 ,@val042 ,@val043 ," +
                " @val044 ,@val045 ,@val046 ,@val047 ,@val048 ,@val049 ,@val050 ,@val051 ,@val052 ,@val053 ,@val054 " +
                 ")";
            return this.insSQLServerEi_MasterSQL;
        }

        public string getSelectDetailTc_OmeDataSQL()
        {
            this.SelectDetailTc_OmeDataSQL =
                " select * from tc_ome_file , omb_file " +
                " where tc_ome05 = omb01 and tc_ome06 = '2' ";

            return this.SelectDetailTc_OmeDataSQL;
        }

        public string getInsSQLServerEi_DetailSQL()
        {
            this.insSQLServerEi_DetailSQL =
                " INSERT INTO EInvoiceDetail (" +
                " InvoiceId ,ProductID ,Description ,Quantity ,Unit ,UnitPrice ,SequenceNumber ,Amount " +
                ")VALUES(" +
                "@val00 ,@val01 ,@val02 ,@val03 ,@val04 ,@val05 ,@val06 ,@val07  " +
                 ")";
            return this.insSQLServerEi_DetailSQL;
        }
    }
}
