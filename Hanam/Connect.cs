using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hanam
{
    internal class Connect
    {
        SqlConnection conn;
        string sql_str;
        public Connect()
        {
            sql_str = @"SERVER=CHUMINHNAM; DATABASE=QLGiaoTrinh; Integrated Security=SSPI;";
        }

        public SqlConnection ConnectDB()
        {
            conn = new SqlConnection(sql_str);
            return conn;
        }

    }
}
