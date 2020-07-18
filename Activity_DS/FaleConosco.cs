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
    public partial class FaleConosco : Form
    {
        DTO_Entidade objEnt;
        public FaleConosco()
        {
            InitializeComponent();
        }
        public FaleConosco(DTO_Entidade objEnt)
        {
            this.objEnt = objEnt;
            InitializeComponent();
            if (objEnt.tipo == "Cliente")
            {
                pictureBox6.Enabled = false;
                pictureBox6.Visible = false;
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home(objEnt);
            hm.ShowDialog();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adm adm = new Adm(objEnt);
            adm.ShowDialog();
            this.Close();
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            this.Hide();
            Perfil pf = new Perfil(objEnt);
            pf.ShowDialog();
            this.Close();
        }
    }
}
