using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InfoStore.Models
{
    public class Loja
    {
        public int LojaID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Cidade { get; set; }

        public virtual List<Funcionario> Funcionarios { get; set; }
        public virtual List<Cliente> Cliente { get; set; }
    }
}