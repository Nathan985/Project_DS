using DAL_Acitivity_DS;
using DTO_Acitivity_DS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Acitivity_DS
{
    public class BLL_Cadastro
    {
        public static string ValidCad(DTO_Cadastro objCad)
        {

            if (string.IsNullOrWhiteSpace(objCad.nome))
            {
                throw new Exception("Campo nome vazio!");
            }
            if (string.IsNullOrWhiteSpace(objCad.email))
            {
                throw new Exception("Campo email vazio!");
            }
            if (string.IsNullOrWhiteSpace(objCad.cpf))
            {
                throw new Exception("Campo cpf vazio!");
            }
            if(objCad.cpf.Length != 11)
            {
                throw new Exception("Campo cpf invalido!");
            }
            if (string.IsNullOrWhiteSpace(objCad.pass))
            {
                throw new Exception("Campo senha vazio!");
            }
            if(objCad.pass.Length < 8)
            {
                throw new Exception("A senha deve conter 8 caracteres!");
            }
            if (string.IsNullOrWhiteSpace(objCad.cnfPass))
            {
                throw new Exception("Campo confirmar senha vazio!");
            }
            if(objCad.pass != objCad.cnfPass)
            {
                throw new Exception("Senhas não são iguais!");
            }
            Conexao.Conectar();

            DAL_Cadastro.CadastroPessoa(objCad);

            return "Sucesso";
        }        
    }
}
