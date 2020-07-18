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
    public class DAL_BuscarProduto
    {

        public static DTO_Produtos Buscar(string Codigo) {

            DTO_Produtos ObjProduto = new DTO_Produtos();

            try {

                string script = "SELECT * FROM tbl_Produto WHERE codBarras = @Codigo";
                SqlCommand cm = new SqlCommand(script, Conexao.Conectar());

                //substitui as variaveis na instruçao sql pelos valores digitados pelo usuario
                cm.Parameters.AddWithValue("@Codigo", Codigo);

                SqlDataReader dados = cm.ExecuteReader();



                while (dados.Read())
                {


                    if (dados.HasRows)
                    {

                        ObjProduto.IdProduto = int.Parse(dados["idProduto"].ToString());
                        ObjProduto.codBarras = dados["codBarras"].ToString();
                        ObjProduto.nome = dados["nome"].ToString();
                        ObjProduto.preco = dados["preco"].ToString();
                        ObjProduto.estoque = dados["estoque"].ToString();
                        ObjProduto.unidade = dados["unidade"].ToString();
                        ObjProduto.tipo = dados["tipo"].ToString();
                        ObjProduto.ativo = bool.Parse(dados["ativo"].ToString());
                        ObjProduto.Imagem = dados["imagem"].ToString();
                        ObjProduto.dadosEncontrados = true;

                        return ObjProduto;

                    }

                }
                ObjProduto.dadosEncontrados = false;
                return ObjProduto;

            }
            catch {

                ObjProduto.dadosEncontrados = false;
                return ObjProduto;

            }
            finally 
            {

                if (Conexao.Conectar().State != ConnectionState.Closed)
                //testando o estado da conexao, se é diferente de fechado
                {
                    Conexao.Conectar().Close();

                }

            }






        }

    }
}
