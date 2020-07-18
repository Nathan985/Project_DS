using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO_Acitivity_DS;
using System.Data;

namespace DAL_Acitivity_DS
{
    public class DAL_Login
    {
        public static DTO_Entidade ValidarLogin(DTO_Login obj)
        {
            try
            {
                string script = "SELECT * FROM tbl_Usuario WHERE(nick = @login OR email = @login) AND senha = @senha AND ativo = 'Ativo' ";
                SqlCommand cm = new SqlCommand(script, Conexao.Conectar());

                //substitui as variaveis na instruçao sql pelos valores digitados pelo usuario
                cm.Parameters.AddWithValue("@login", obj.nome);
                cm.Parameters.AddWithValue("@senha", obj.senha);

                SqlDataReader dados = cm.ExecuteReader();
                //roda a intruçao sql e atribui resultado no SqlDataReader

                DTO_Entidade objent = new DTO_Entidade();

                while (dados.Read())
                //le a proxima linha do resultado da sua instruçao
                {
                    if (dados.HasRows)
                    //se der certo vai aparecer a message de conexao feita
                    {
                        objent.idUser = int.Parse(dados["idUser"].ToString());
                        objent.nome = dados["nome"].ToString();
                        objent.email = dados["email"].ToString();
                        objent.nick = dados["nick"].ToString();
                        objent.senha = dados["senha"].ToString();
                        objent.tipo = dados["tipo"].ToString();
                        objent.ativo = dados["ativo"].ToString();
                        objent.cpf = dados["cpf"].ToString();

                        objent.loginStatus = true;

                        return objent;
                    }
                }

                objent.loginStatus = false;

                return objent;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro de conexão, contate o suporte! " + ex.Message);
            
            }
            finally //finally acontece independente se acontece o try ou catch
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
