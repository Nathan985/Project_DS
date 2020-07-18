using DTO_Acitivity_DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Acitivity_DS;

namespace BLL_Acitivity_DS
{
    public class BLL_BuscarProduto
    {
        public static DTO_Produtos BuscarProduto(string codbarras) {

            DTO_Produtos ObjProduto;


            if (string.IsNullOrEmpty(codbarras))
            {

                throw new Exception("Digite o Codigo de Barras");

            }
            else if (codbarras.Length != 13) {

                throw new Exception("Codigo de Barras Invalido");

            }

            ObjProduto = DAL_BuscarProduto.Buscar(codbarras);

            if (!ObjProduto.dadosEncontrados) {

                throw new Exception("Codigo não encontrado");

            }

            return ObjProduto;
        
        }
    }
}
