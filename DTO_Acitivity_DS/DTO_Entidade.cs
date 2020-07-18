using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Acitivity_DS
{
    public class DTO_Entidade
    {

        public int idUser { get; set; }

        public string nome { get; set; }

        public string email { get; set; }

        public string nick { get; set; }

        public string senha { get; set; }

        public string tipo { get; set; }

        public string ativo { get; set; }

        public string cpf { get; set; }

        public bool loginStatus { get; set; }

    }
}
