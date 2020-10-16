using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate2QBoss
{
    class OraEi_MasterObject
    {
        private int id;
        private string invoiceNumber;
        private int status;
        private int purpose;
        private string invoiceDate;
        private string customerID;
        private string customerName;
        private string customerTaxID;
        private int invoiceType;
        private int printMark;
        private int randomNumber;
        private string carrierType;
        private string carrierID;
        private int salesAmount;
        private int freeTaxSalesAmount;
        private int zeroTaxSalesAmount;
        private int taxAmount;
        private int taxType;
        private decimal taxRate;
        private int totalAmount;
        private string donateNo;
        private int donateMark;
        private int exported;
        private int groupMark;
        private string sellerTaxID;
        private string sellerName;
        private string sellerAddress;
        private string machineCode;
        private int machineSerialNum;
        private int cancelExported;
        private string cancelReason;
        private string cancelTime;
        private string notes;
        private int voidExported;
        private string voidReason;

        public string InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public string InvoiceDate { get => invoiceDate; set => invoiceDate = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string CustomerTaxID { get => customerTaxID; set => customerTaxID = value; }
        public int SalesAmount { get => salesAmount; set => salesAmount = value; }
        public int FreeTaxSalesAmount { get => freeTaxSalesAmount; set => freeTaxSalesAmount = value; }
        public int ZeroTaxSalesAmount { get => zeroTaxSalesAmount; set => zeroTaxSalesAmount = value; }
        public int TaxAmount { get => taxAmount; set => taxAmount = value; }
        public decimal TaxRate { get => taxRate; set => taxRate = value; }
        public int TotalAmount { get => totalAmount; set => totalAmount = value; }



    }
}
