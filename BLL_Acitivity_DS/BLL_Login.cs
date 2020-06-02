using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using DAL_Acitivity_DS;
using DTO_Acitivity_DS;

namespace BLL_Acitivity_DS
{
    public class BLL_Login
    {

        public static string ValidarLogin(DTO_Login ObjLog)
        {

            if (string.IsNullOrWhiteSpace(ObjLog.nome))
            {
                throw new Exception("Campo nome vazio");
            }
            if (string.IsNullOrWhiteSpace(ObjLog.senha))
            {
                throw new Exception("Campo senha vazio");
            }

            Conexao.Conectar();

            return DAL_Login.ValidarLogin(ObjLog);
        }

    }
}
