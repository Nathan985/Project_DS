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
using DTO_Acitivity_DS;

namespace Activity_DS
{
    public partial class Perfil : Form
    {
        DTO_Entidade ObjEnt;
        public Perfil()
        {
            InitializeComponent();
        }
        public Perfil(DTO_Entidade ObjEnt)
        {
            InitializeComponent();

            box_name.Text = ObjEnt.nome;
            box_cpf.Text = ObjEnt.cpf;
            box_Email.Text = ObjEnt.email;
            box_senha.Text = ObjEnt.senha;
            box_cargo.Text = ObjEnt.tipo;
            box_nick.Text = ObjEnt.nick;
            TitlePf.Text = "Bem-Vindo " + ObjEnt.nome;

            this.ObjEnt = ObjEnt;

            if (ObjEnt.tipo == "Cliente")
            {
                pictureBox6.Enabled = false;
                pictureBox6.Visible = false;
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home(this.ObjEnt);
            hm.ShowDialog();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adm adm = new Adm(ObjEnt);
            adm.ShowDialog();
            this.Close();
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            this.Hide();
            FaleConosco fl = new FaleConosco(ObjEnt);
            fl.ShowDialog();
            this.Close();
        }
    }
}
