using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Acitivity_DS
{
    public class DTO_Produtos
    {
        public int IdProduto { get; set; }
        public string codBarras { get; set; }
        public string nome { get; set; }
        public string preco { get; set; }
        public string estoque { get; set; }
        public string unidade { get; set; }
        public string tipo { get; set; }
        public bool ativo { get; set; }
        public string Imagem { get; set; }
        public bool dadosEncontrados { get; set; }
        public bool valor { get; set; }


    }
}
