using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfoStore.Models;

namespace InfoStore.Models
{
    public class Compra
    {
        public int CompraID { get; set; }
        public int ProdutoID { get; set; }
        public int Quant { get; set; }
        public decimal CustoProduto { get; set; }
        public decimal Total { get { return CustoProduto * Quant; } }
        public int LojaID { get; set; }

        public virtual ICollection<Loja> Lojas { get; set; }
        public Produto Produto { get; set; }
        public Loja Loja { get; set; }
    }
}