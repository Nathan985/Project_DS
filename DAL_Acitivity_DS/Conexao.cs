using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Acitivity_DS;
using System.Data.SqlClient;

namespace DAL_Acitivity_DS
{
    public class Conexao
    {

        public static SqlConnection Conectar()
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Activity_DS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                conn.Open();
                return conn;
            }
            catch
            {
                throw new Exception("Conexão não foi realizada");
            }
        }

    }
}
