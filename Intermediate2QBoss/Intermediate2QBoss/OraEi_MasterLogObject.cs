using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate2QBoss
{
    class OraEi_MasterLogObject
    {
        private int invoiceId;
        private string logName;
        private string logMessage;
        private string modUser;

        public int InvoiceId { get => invoiceId; set => invoiceId = value; }
        public string LogName { get => logName; set => logName = value; }
        public string LogMessage { get => logMessage; set => logMessage = value; }
        public string ModUser { get => modUser; set => modUser = value; }
    }
}
