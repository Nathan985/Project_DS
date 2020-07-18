using BLL_Acitivity_DS;
using DTO_Acitivity_DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_Activity_DS;

namespace Activity_DS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Log_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Login objLog = new DTO_Login();
                objLog.nome = name_Log.Text;
                objLog.senha = pass_Log.Text;
                DTO_Entidade objEnt = new DTO_Entidade();

                objEnt = BLL_Login.ValidarLogin(objLog);

                if (objEnt.loginStatus)
                {
                    
                    if(objEnt.tipo == "Cliente")
                    {
                        this.Hide();
                        Home hm = new Home(objEnt);
                        hm.ShowDialog();
                        this.Close();
                    }
                    else if(objEnt.tipo == "Admin" || objEnt.tipo == "Funcionario" || objEnt.tipo == "Operador")
                    {
                        this.Hide();
                        Adm adm = new Adm(objEnt);
                        adm.ShowDialog();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Usuario ou Senha invalidos", "ERRO LOGIN", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cadastro cad = new Cadastro();
            cad.ShowDialog();
            this.Close();
        }
    }
}
