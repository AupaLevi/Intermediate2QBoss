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
    }
}
