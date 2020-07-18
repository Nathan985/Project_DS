using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DTO_Acitivity_DS;
using DAL_Acitivity_DS;

namespace BLL_Acitivity_DS
{
    public class BLL_Produto
    {

        public static string ValidarProdutos(DTO_Produtos ObjProduto) {

            try
            {
                double result;
                int resultint;
                if (string.IsNullOrWhiteSpace(ObjProduto.codBarras))
                {
                    throw new Exception("Codigo Vazio");
                }
                else if (ObjProduto.codBarras.Length != 13 || !Int64.TryParse(ObjProduto.codBarras, out Int64 resultint64))
                {
                    throw new Exception("Codigo Invalido");
                }
                if (DAL_ValidarProduto.BuscarProduto(ObjProduto.codBarras))
                {
                    throw new Exception("Codigo já cadastrado");
                }
                if (string.IsNullOrWhiteSpace(ObjProduto.nome))
                {
                    throw new Exception("Nome Vazio");
                }

                if (string.IsNullOrWhiteSpace(ObjProduto.preco))
                {
                    throw new Exception("Preço Vazio");
                }
                if (!double.TryParse(ObjProduto.preco, out result))
                {
                    throw new Exception("Preço Invalido");
                }
                if (string.IsNullOrWhiteSpace(ObjProduto.estoque))
                {
                    throw new Exception("Estoque Vazio");
                }
                if (!int.TryParse(ObjProduto.estoque, out resultint))
                {
                    throw new Exception("Estoque Invalido");
                }
                if (string.IsNullOrWhiteSpace(ObjProduto.unidade))
                {
                    throw new Exception("Unidade Vazia");
                }
                if (!double.TryParse(ObjProduto.unidade, out result))
                {
                    throw new Exception("Unidade Invalida");
                }
                if (string.IsNullOrWhiteSpace(ObjProduto.tipo))
                {
                    throw new Exception("Tipo Vazio");
                }
                if (ObjProduto.valor)
                {
                    throw new Exception("Ativo Vazio");
                }

                if (string.IsNullOrWhiteSpace(ObjProduto.Imagem)) {
                    throw new Exception("Adicione uma Imagem");
                }

                if (DAL_Produtos.CadastrarProduto(ObjProduto))
                {
                    return "Cadastro Realizado";
                }
                else {
                    return "Erro ao Cadastrar";
                }

            }
            catch (Exception ex) {

                return ex.Message;

            }
        }

    }
}
