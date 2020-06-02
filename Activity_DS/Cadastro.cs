using DTO_Acitivity_DS;
using BLL_Acitivity_DS;
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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        public void Limpar()
        {
            name_Cad.Clear();
            email_Cad.Clear();
            cpf_Cad.Clear();
            nick_Cad.Clear();
            pass_Cad.Clear();
            confPass_Cad.Clear();
        }

        private void btn_Cad_Click(object sender, EventArgs e)
        {
            try
            {
                DTO_Cadastro objCad = new DTO_Cadastro();

                objCad.nome = name_Cad.Text;
                objCad.email = email_Cad.Text;
                objCad.cpf = cpf_Cad.Text;
                objCad.nick = nick_Cad.Text;
                objCad.pass = pass_Cad.Text;
                objCad.cnfPass = confPass_Cad.Text;

                MessageBox.Show(BLL_Cadastro.ValidCad(objCad));

                Limpar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.ShowDialog();
            this.Close();
        }

        private void pictureBox24_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.ShowDialog();
            this.Close();
        }
    }
}
