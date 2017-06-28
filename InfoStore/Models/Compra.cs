using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using InfoStore.Models;

namespace InfoStore.Models
{
    public class Compra
    {
        public int CompraID { get; set; }

        public Compra()
        {
            Produtos = new List<Produto>();
        }

        public int Quant { get; set; }
        public decimal Total { get { return CustoProduto * Quant; } }
        public int LojaID { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoID { get; set; }

        [ForeignKey("Produto")]
        public decimal CustoProduto {
            get
            {  var query = Produtos.Where(Produto => Produto.ProdutoID == ProdutoID);
                return query.Sum(o => o.CustoProduto);
            }
        }


        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Loja> Lojas { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Loja Loja { get; set; }
    }
}