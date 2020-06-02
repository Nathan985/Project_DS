using Activity_DS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Activity_DS
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adm adm = new Adm();
            adm.ShowDialog();
            this.Close();
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            this.Hide();
            Perfil pf = new Perfil();
            pf.ShowDialog();
            this.Close();
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            this.Hide();
            FaleConosco fl = new FaleConosco();
            fl.ShowDialog();
            this.Close();
        }
    }
}
