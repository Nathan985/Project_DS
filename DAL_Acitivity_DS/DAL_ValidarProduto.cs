using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Acitivity_DS
{
    public class DAL_ValidarProduto
    {

        public static bool BuscarProduto(string cod) {

            try
            {

                string script = "SELECT * FROM tbl_Produto WHERE codBarras = @Codigo";
                SqlCommand cm = new SqlCommand(script, Conexao.Conectar());

                cm.Parameters.AddWithValue("@Codigo", cod);

                SqlDataReader dados = cm.ExecuteReader();

                if (dados.Read())
                {
                    if (dados.HasRows)
                    {
                        return true;
                    }
                }

                return false;


            }
            catch
            {
                return false;
            }
            finally {

                if (Conexao.Conectar().State != ConnectionState.Closed)
                {
                    Conexao.Conectar().Close();

                }
            }
        
        }

    }
}
