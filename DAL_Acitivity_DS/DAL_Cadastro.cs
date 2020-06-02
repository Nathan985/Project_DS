using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Acitivity_DS;
using System.Data;
using System.Data.SqlClient;

namespace DAL_Acitivity_DS
{
    public class DAL_Cadastro
    {
        public static string CadastroPessoa(DTO_Cadastro objCad)
        {
            string script = "INSERT INTO tbl_Usuario (nome, email, nick, senha, cpf) values " +
                "(@nome, @email, @nick, @senha, @cpf)";
            SqlCommand cm = new SqlCommand(script, Conexao.Conectar());
            cm.Parameters.AddWithValue("@nome", objCad.nome);
            cm.Parameters.AddWithValue("@email", objCad.email);
            cm.Parameters.AddWithValue("@nick", objCad.nick);
            cm.Parameters.AddWithValue("@senha", objCad.pass);
            cm.Parameters.AddWithValue("@cpf", objCad.cpf);

            cm.ExecuteNonQuery();

            

            if (Conexao.Conectar().State != ConnectionState.Closed)
            //testando o estado da conexao, se é diferente de fechado
            {
                Conexao.Conectar().Close();

            }

            return "Cadastro concluido!";
        }
    }
}
