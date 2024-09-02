using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_login_Date
{
    public class Conexion
    {
        public string getCatedenaSQL()
        {
            return "Server=LAPTOP-F9M70AR5\\SQLEXPRESS01; Database=LoginUsers; Trusted_Connection=True;";

        }
    }
}
