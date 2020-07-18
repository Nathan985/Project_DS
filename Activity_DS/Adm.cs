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
using BLL_Acitivity_DS;
using System.IO;
using System.Security.Cryptography;

namespace Activity_DS
{
    public partial class Adm : Form
    {
        DTO_Entidade ObjEnt;
        string Imgorigem;
        string ImgDestino = @"C:\Activity_DS\Produtos_IMG";
        string ImgName;
        string alt_Imagem;
        string alt_Imgorigem;
        string alt_destino_Imagem;
        int idProduto;
        public Adm()
        {
            InitializeComponent();
        }
        public Adm(DTO_Entidade objEnt)
        {
            InitializeComponent();

            this.ObjEnt = objEnt;

            lb_pf_nome.Text = "Operador(a): " + char.ToUpper(objEnt.nome[0]) + objEnt.nome.Substring(1);
            lb_pf_email.Text = char.ToUpper(objEnt.email[0]) + objEnt.email.Substring(1);
            lb_pf_cargo.Text = char.ToUpper(objEnt.tipo[0]) + objEnt.tipo.Substring(1);

            entrada_pf.Text = "Entrada: " + DateTime.Now.ToString();
            saida_pf.Text = "Saída: " + DateTime.Now.AddHours(9).ToString();
            switch (objEnt.tipo) {
                case "Admin":
  
                ActivityAdmin(objEnt);
                    break;

                case "Funcionario":
                
                ActivityFuncionario(objEnt);
                    break;

                case "Operador":

                    ActivityOperador(objEnt);
                    break;
            }

        }

        public void ActivityAdmin(DTO_Entidade objEnt) {

            lb_vd_nome.Text = "Operador(a): " + char.ToUpper(objEnt.nome[0]) + objEnt.nome.Substring(1);
            lb_pd_nome.Text = "Operador(a): " + char.ToUpper(objEnt.nome[0]) + objEnt.nome.Substring(1);
            lb_fn_nome.Text = "Operador(a): " + char.ToUpper(objEnt.nome[0]) + objEnt.nome.Substring(1);
            lb_rl_nome.Text = "Operador(a): " + char.ToUpper(objEnt.nome[0]) + objEnt.nome.Substring(1);

        }
        public void ActivityOperador(DTO_Entidade objEnt) {

            tabControl1.TabPages.Remove(PageProdutos);
            tabControl1.TabPages.Remove(PageFuncionários);
            tabControl1.TabPages.Remove(PageVendas);

        }
        public void ActivityFuncionario(DTO_Entidade objEnt) {

            lb_vd_nome.Text = "Operador(a): " + char.ToUpper(objEnt.nome[0]) + objEnt.nome.Substring(1);
            tabControl1.TabPages.Remove(PageProdutos);
            tabControl1.TabPages.Remove(PageFuncionários);
            tabControl1.TabPages.Remove(PageRelatório);

            lb_pd_nome.Text = "Operador(a): " + char.ToUpper(objEnt.nome[0]) + objEnt.nome.Substring(1);

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home(ObjEnt);
            hm.ShowDialog();
            this.Close();

        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            this.Hide();
            Perfil pf = new Perfil(ObjEnt);
            pf.ShowDialog();
            this.Close();
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            this.Hide();
            FaleConosco fl = new FaleConosco(ObjEnt);
            fl.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            recado_Inp.Clear();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            cod_Inp.Clear();
            qtd_Inp.Clear();
            nomePd_Inp.Clear();
            preco_Inp.Text = "R$";
            list_Pd.Items.Clear();
            rad_dinheiro.Checked = false;
            rad_Deb.Checked = false;
            rad_Cred.Checked = false;
            total_label.Text = "Total:";
            recebido_label.Text = "Recebido:";
            troco_label.Text = "Troco";
            frmPaga_label.Text = "Forma de Pagamento";
            //data_label.Text = DateTime.Now.ToString();
            data_label.Text = "00/00/00 - 00:00:00";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LimparProdutos();
        }

        private void LimparProdutos() {

            codigo_Pd.Clear();
            nome_Pd.Clear();
            preco_Pd.Clear();
            estoque_Pd.Clear();
            unidade_Pd.Clear();
            tipo_unidade_Pd.SelectedIndex = -1;
            ativo_Pd.Checked = false;
            desativo_Pd.Checked = false;
            Img_Produtos.ImageLocation = @"C:\Users\NATHANPEREIRACAVALCA\source\repos\Activity_DS\Activity_DS\Resources\icons8-produto-1001.png";


        }

        private void button6_Click(object sender, EventArgs e)
        {
            DTO_Produtos ObjProduto = new DTO_Produtos();

            ObjProduto.codBarras = codigo_Pd.Text;
            ObjProduto.nome = nome_Pd.Text;
            ObjProduto.preco = preco_Pd.Text;
            ObjProduto.estoque = estoque_Pd.Text;
            ObjProduto.unidade = unidade_Pd.Text;
            ObjProduto.tipo = tipo_unidade_Pd.Text;
            ObjProduto.Imagem = ImgName;
            if (ativo_Pd.Checked){
                ObjProduto.ativo = true;
            }
            if (desativo_Pd.Checked) {
                ObjProduto.ativo = false;
            }
            if (ativo_Pd.Checked == false && desativo_Pd.Checked == false) {
                ObjProduto.valor = true;
            }

            string Message = BLL_Produto.ValidarProdutos(ObjProduto);

            /*case "Codigo Vazio":
                    MessageBox.Show(Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;*/

            switch (Message) {
                case "Cadastro Realizado":
                    MessageBox.Show("Cadastro Realizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Copy(Imgorigem, ImgDestino);
                    LimparProdutos();
                    break;
                default:
                    MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            string pasta = @"C:\Activity_DS\Produtos_IMG";
            if (!Directory.Exists(pasta)) {
                Directory.CreateDirectory(pasta);
            }

            OpenFileDialog imgProduto = new OpenFileDialog();

            if (imgProduto.ShowDialog() == DialogResult.OK) {

                Img_Produtos.ImageLocation = imgProduto.FileName;
                Img_Produtos.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Imgorigem = imgProduto.FileName;
                MD5 hash = MD5.Create();
                byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(Imgorigem));

                StringBuilder Hash_img = new StringBuilder();

                for (int i = 0; i < data.Length; i++){

                    Hash_img.Append(data[i].ToString("x2"));
                
                }
                this.ImgName = Hash_img.ToString() + ".png";

                this.ImgDestino = Path.Combine(ImgDestino, ImgName);

            }
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            try
            {

                DTO_Produtos ObjProduto;
                ObjProduto = BLL_BuscarProduto.BuscarProduto(alt_Codigo.Text);

                if (ObjProduto.dadosEncontrados) {

                    SetProduto(ObjProduto);
                
                }

            }
            catch(Exception ex){

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void SetProduto(DTO_Produtos ObjProduto) {

            alt_name.Text = ObjProduto.nome;
            alt_Preco.Text = ObjProduto.preco;
            alt_estoque.Text = ObjProduto.estoque;
            alt_unidade.Text = ObjProduto.unidade;
            switch (ObjProduto.tipo) {

                case "Un":
                    alt_tipo.SelectedIndex = 0;
                    break;
                case "g":
                    alt_tipo.SelectedIndex = 1;
                    break;
                case "Kg":
                    alt_tipo.SelectedIndex = 2;
                    break;
                case "L":
                    alt_tipo.SelectedIndex = 3;
                    break;
                case "Ml":
                    alt_tipo.SelectedIndex = 4;
                    break;
            }
            //alt_tipo
            if (ObjProduto.ativo)
            {

                alt_ativo.Checked = true;


            }
            else {

                alt_desativo.Checked = true;


            }
            alt_img.ImageLocation = @"C:\Activity_DS\Produtos_IMG\" + ObjProduto.Imagem;

            alt_name.Enabled = true;
            alt_Preco.Enabled = true;
            alt_estoque.Enabled = true;
            alt_unidade.Enabled = true;
            alt_tipo.Enabled = true;
            alt_ativo.Enabled = true;
            alt_desativo.Enabled = true;
            pictureBox32.Enabled = true;
            alt_btn.Enabled = true;

            alt_Imagem = ObjProduto.Imagem;
            idProduto = ObjProduto.IdProduto;


        }

        private void alt_btn_Click(object sender, EventArgs e)
        {

            try
            {
                DTO_Produtos ObjProduto = new DTO_Produtos();

                ObjProduto.IdProduto = this.idProduto;
                ObjProduto.codBarras = alt_Codigo.Text;
                ObjProduto.nome = alt_name.Text;
                ObjProduto.preco = alt_Preco.Text;
                ObjProduto.estoque = alt_estoque.Text;
                ObjProduto.unidade = alt_unidade.Text;
                ObjProduto.tipo = alt_tipo.Text;
                ObjProduto.Imagem = alt_Imagem;
                if (ativo_Pd.Checked)
                {
                    ObjProduto.ativo = true;
                }
                else if (desativo_Pd.Checked)
                {
                    ObjProduto.ativo = false;
                }

                bool result = BLL_AlterarProduto.ValidarAlteracao(ObjProduto);

                if (result)
                {

                    MessageBox.Show("Alteração Realizada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (File.Exists(alt_destino_Imagem)) {

                        File.Delete(alt_destino_Imagem);

                    }
                    if (!string.IsNullOrWhiteSpace(alt_destino_Imagem)) {
                        File.Copy(alt_Imgorigem, alt_destino_Imagem);
                    }
                   

                }
                else {

                    MessageBox.Show("Cadastro não Realizado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch(Exception ex) {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            string pasta = @"C:\Activity_DS\Produtos_IMG";;
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            OpenFileDialog imgProduto = new OpenFileDialog();

            if (imgProduto.ShowDialog() == DialogResult.OK)
            {
                alt_img.ImageLocation = imgProduto.FileName;
                alt_Imgorigem = imgProduto.FileName;
                Img_Produtos.SizeMode = PictureBoxSizeMode.StretchImage;
                this.alt_destino_Imagem = Path.Combine(ImgDestino, this.alt_Imagem);

            }
        }
    }
}
