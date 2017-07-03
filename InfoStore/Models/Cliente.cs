using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfoStore.Models
{
    public class Cliente
    {
        [DisplayName("Cliente")]
        public int ClienteID { get; set; }

        [DisplayName("Nome")]
        public  string NomeCliente { get; set; }
        
        [ForeignKey("Loja")]
        public int LojaID { get; set; }


        [DisplayName("Cidade")]
        public virtual Loja Loja { get; set; }
    }
}