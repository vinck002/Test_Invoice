using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Invoice.Config
{
   public  class SqlCon
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString.ToString();
        public string ConnectionSt { get => _connectionString; }
    }
}
