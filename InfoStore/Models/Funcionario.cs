using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoStore.Models
{
    public class Funcionario
    {
        public int FuncionarioID { get; set; }
        public string NomeFuncionario { get; set; }

        public int LojaID { get; set; }

        public virtual ICollection<Loja> Lojas { get; set; }
    }
}