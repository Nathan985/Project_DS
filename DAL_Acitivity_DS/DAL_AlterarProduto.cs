using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Acitivity_DS;

namespace DAL_Acitivity_DS
{
    public class DAL_AlterarProduto
    {

        public static bool AlterarProduto(DTO_Produtos ObjProduto) {

            try
            {
                string sql = "UPDATE tbl_Produto SET nome = @Nome, preco = @Preco, estoque = @Estoque, unidade = @Unidade, tipo = @Tipo, ativo = @Ativo, imagem = @Imagem WHERE idProduto = @IdProduto ";
                SqlCommand cm = new SqlCommand(sql, Conexao.Conectar());
                cm.Parameters.AddWithValue("@Nome", ObjProduto.nome);
                cm.Parameters.AddWithValue("@Preco", ObjProduto.preco);
                cm.Parameters.AddWithValue("@Estoque", ObjProduto.estoque);
                cm.Parameters.AddWithValue("@Unidade", ObjProduto.unidade);
                cm.Parameters.AddWithValue("@Tipo", ObjProduto.tipo);
                cm.Parameters.AddWithValue("@Ativo", ObjProduto.ativo);
                cm.Parameters.AddWithValue("@Imagem", ObjProduto.Imagem);
                cm.Parameters.AddWithValue("@IdProduto", ObjProduto.IdProduto);

                cm.ExecuteNonQuery();

                return true;

            }
            catch(Exception ex)
            {

                throw new Exception(ex.Message);

            }
            finally {
                if (Conexao.Conectar().State != ConnectionState.Closed)
                //testando o estado da conexao, se é diferente de fechado
                {
                    Conexao.Conectar().Close();

                }
            }
        
        }

    }
}
