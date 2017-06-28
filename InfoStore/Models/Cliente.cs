using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoStore.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public  string NomeCliente { get; set; }

        public int LojaID { get; set; }

        public virtual ICollection<Loja> Lojas { get; set; }
    }
}