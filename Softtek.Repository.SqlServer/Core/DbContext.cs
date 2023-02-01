using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Softtek.Repository.SqlServer.Core
{
    public  class DbContext
    {
        public static MySqlConnection connection()
        {
            
            MySqlConnection cn = new MySqlConnection("Server=localhost; Port=3307; Database=softtek; Uid=root; Pwd=123;");
            return cn;
        }


    }
}
