using DTO_Acitivity_DS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Acitivity_DS
{
    public class DAL_Produtos
    {
        public static bool CadastrarProduto(DTO_Produtos ObjProduto) {

            try {

                string script = "INSERT INTO tbl_Produto (codBarras, nome, preco, estoque, unidade, tipo, ativo, imagem) values " +
                    "(@CodBarras, @Nome, @Preco, @Estoque, @Unidade, @Tipo, @Ativo, @Imagem)";

                SqlCommand cm = new SqlCommand(script, Conexao.Conectar());
                cm.Parameters.AddWithValue("@CodBarras", ObjProduto.codBarras);
                cm.Parameters.AddWithValue("@Nome", ObjProduto.nome);
                cm.Parameters.AddWithValue("@Preco", ObjProduto.preco);
                cm.Parameters.AddWithValue("@Estoque", ObjProduto.estoque);
                cm.Parameters.AddWithValue("@Unidade", ObjProduto.unidade);
                cm.Parameters.AddWithValue("@Tipo", ObjProduto.tipo);
                cm.Parameters.AddWithValue("@Ativo", ObjProduto.ativo);
                cm.Parameters.AddWithValue("@Imagem", ObjProduto.Imagem);

                cm.ExecuteNonQuery();

                if (Conexao.Conectar().State != ConnectionState.Closed)
                {
                    Conexao.Conectar().Close();

                }

                return true;


            } 
            catch{

                return false;
            
            }

        }
    }
}
