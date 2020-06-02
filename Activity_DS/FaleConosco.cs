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
        public FaleConosco()
        {
            InitializeComponent();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home();
            hm.ShowDialog();
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
    }
}
