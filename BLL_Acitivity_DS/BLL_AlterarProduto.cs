using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Acitivity_DS;
using DAL_Acitivity_DS;

namespace BLL_Acitivity_DS
{
    public class BLL_AlterarProduto : BLL_BuscarProduto
    {

        public static bool ValidarAlteracao(DTO_Produtos ObjProduto) {

            if (ValidarCampo(ObjProduto.codBarras))
            {
                throw new Exception("Digite o Codigo de Barras");
            }
            else {
                DTO_Produtos ObjCod;
                ObjCod = BuscarProduto(ObjProduto.codBarras);
                if (!ObjCod.dadosEncontrados) {

                    throw new Exception("Codigo de Barras Invalido");

                }
            }
            if (ValidarCampo(ObjProduto.nome)) {
                throw new Exception("Campo Nome Vazio");
            }
            if (ValidarCampo(ObjProduto.preco)) {
                throw new Exception("Campo Preço Vazio");
            }
            if (!double.TryParse(ObjProduto.preco, out double pm)) {
                throw new Exception("Preço Invalido");
            }
            if (ValidarCampo(ObjProduto.estoque)) {
                throw new Exception("Campo Estoque Vazio");
            }
            if (!int.TryParse(ObjProduto.estoque, out int pmint)) {
                throw new Exception("Estoque Invalido");
            }
            if (ValidarCampo(ObjProduto.unidade)) {
                throw new Exception("Campo Unidade Vazio");
            }
            if (!double.TryParse(ObjProduto.unidade, out pm)) {
                throw new Exception("unidade Invalida");
            }
            if (ValidarCampo(ObjProduto.tipo)) {
                throw new Exception("Campo Tipo Vazio");
            }
            if (ValidarCampo(ObjProduto.ativo)) {
                throw new Exception("Campo Ativo Vazio");
            }
            if (ValidarCampo(ObjProduto.Imagem)) {
                throw new Exception("Campo Imagem Vazio");
            }

            bool result = DAL_AlterarProduto.AlterarProduto(ObjProduto);
            if (result)
            {
                return true;
            }
            else {
                return false;
            }
            
        }
        private static bool ValidarCampo(string campo)
        {

            if (string.IsNullOrWhiteSpace(campo))
            {

                return true;

            }
            else {

                return false;
            
            }

        }
         private static bool ValidarCampo(bool campo)
         {

            if (campo == true || campo == false)
            {

                return false;

            }
            else {
                return true;
            }

        }

    }
}
