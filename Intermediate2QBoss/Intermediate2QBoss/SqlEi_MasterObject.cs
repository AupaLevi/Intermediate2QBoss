using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate2QBoss
{
    class SqlEi_MasterObject
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
        private decimal salesAmount;
        private decimal freeTaxSalesAmount;
        private decimal zeroTaxSalesAmount;
        private decimal taxAmount;
        private int taxType;
        private decimal taxRate;
        private decimal totalAmount;
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
        private string voidTime;
        private int inErrorList;
        private int uploadStatus;
        private string uploadMessage;
        private string iOType;
        private string rejectReason;
        private string rejectTime;
        private int creditCard;
        private int cash;
        private int cashDiscount;
        private int invoiceSpecies;
        private int invType;
        private string orderNo;
        private int customsClearanceMark;
        private string creditCardLast4No;
        private string customerAddress;
        private string messageBeginTime;
        private string webPrintState;
        private int vAT;

        public int Id { get => id; set => id = value; }
        public string InvoiceNumber { get => invoiceNumber; set => invoiceNumber = value; }
        public int Status { get => status; set => status = value; }
        public int Purpose { get => purpose; set => purpose = value; }
        public string InvoiceDate { get => invoiceDate; set => invoiceDate = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public string CustomerTaxID { get => customerTaxID; set => customerTaxID = value; }
        public int InvoiceType { get => invoiceType; set => invoiceType = value; }
        public int PrintMark { get => printMark; set => printMark = value; }
        public int RandomNumber { get => randomNumber; set => randomNumber = value; }
        public string CarrierType { get => carrierType; set => carrierType = value; }
        public string CarrierID { get => carrierID; set => carrierID = value; }
        public decimal SalesAmount { get => salesAmount; set => salesAmount = value; }
        public decimal FreeTaxSalesAmount { get => freeTaxSalesAmount; set => freeTaxSalesAmount = value; }
        public decimal ZeroTaxSalesAmount { get => zeroTaxSalesAmount; set => zeroTaxSalesAmount = value; }
        public decimal TaxAmount { get => taxAmount; set => taxAmount = value; }
        public int TaxType { get => taxType; set => taxType = value; }
        public decimal TaxRate { get => taxRate; set => taxRate = value; }
        public decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
        public string DonateNo { get => donateNo; set => donateNo = value; }

        public int DonateMark { get => donateMark; set => donateMark = value; }

        public int Exported { get => exported; set => exported = value; }

        public int GroupMark { get => groupMark; set => groupMark = value; }
        public string SellerTaxID { get => sellerTaxID; set => sellerTaxID = value; }

        public string SellerName { get => sellerName; set => sellerName = value; }
        public string SellerAddress { get => sellerAddress; set => sellerAddress = value; }
        public string MachineCode { get => machineCode; set => machineCode = value; }
        public int MachineSerialNum { get => machineSerialNum; set => machineSerialNum = value; }
        public int CancelExported { get => cancelExported; set => cancelExported = value; }
        public string CancelReason { get => cancelReason; set => cancelReason = value; }
        public string CancelTime { get => cancelTime; set => cancelTime = value; }
        public string Notes { get => notes; set => notes = value; }
        public int VoidExported { get => voidExported; set => voidExported = value; }
        public string VoidReason { get => voidReason; set => voidReason = value; }
        public string VoidTime { get => voidTime; set => voidTime = value; }
        public int InErrorList { get => inErrorList; set => inErrorList = value; }
        public int UploadStatus { get => uploadStatus; set => uploadStatus = value; }
        public string UploadMessage { get => uploadMessage; set => uploadMessage = value; }
        public string IOType { get => iOType; set => iOType = value; }
        public string RejectReason { get => rejectReason; set => rejectReason = value; }
        public string RejectTime { get => rejectTime; set => rejectTime = value; }
        public int CreditCard { get => creditCard; set => creditCard = value; }
        public int Cash { get => cash; set => cash = value; }
        public int CashDiscount { get => cashDiscount; set => cashDiscount = value; }
        public int InvoiceSpecies { get => invoiceSpecies; set => invoiceSpecies = value; }
        public int InvType { get => invType; set => invType = value; }
        public string OrderNo { get => orderNo; set => orderNo = value; }
        public int CustomsClearanceMark { get => customsClearanceMark; set => customsClearanceMark = value; }
        public string CreditCardLast4No { get => creditCardLast4No; set => creditCardLast4No = value; }
        public string CustomerAddress { get => customerAddress; set => customerAddress = value; }
        public string MessageBeginTime { get => messageBeginTime; set => messageBeginTime = value; }
        public string WebPrintState { get => webPrintState; set => webPrintState = value; }
        public int VAT { get => vAT; set => vAT = value; }
    }
}
