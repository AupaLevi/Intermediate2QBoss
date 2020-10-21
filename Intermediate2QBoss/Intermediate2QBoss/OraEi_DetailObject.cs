using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate2QBoss
{
    class OraEi_DetailObject
    {
        private int invoiceId;
        private string productID;
        private string description;
        private decimal quantity;
        private string unit;
        private decimal unitPrice;
        private int sequenceNumber;
        private decimal amount;

        public int InvoiceId { get => invoiceId; set => invoiceId = value; }
        public string ProductID { get => productID; set => productID = value; }
        public string Description { get => description; set => description = value; }
        public decimal Quantity { get => quantity; set => quantity = value; }
        public string Unit { get => unit; set => unit = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int SequenceNumber { get => sequenceNumber; set => sequenceNumber = value; }
        public decimal Amount { get => amount; set => amount = value; }
    }
}
