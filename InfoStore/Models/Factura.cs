using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using InfoStore.Models;

namespace InfoStore.Models
{
    public class Factura
    {
        public Factura()
        {
            Produtos = new List<Produto>();
            Configs = new List<Config>();
        }

        public int FacturaID { get; set; }

        [ForeignKey("Funcionario")]
        public int FuncionarioID { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoID { get; set; }

        [ForeignKey("Config")]
        public int ConfigID { get; set; }

        public int Quant_Prod { get; set; }
        public int Quant_Config { get; set; }

        public decimal total_factura
        {
            get
            {
                var query = Produtos.Where(Produto => Produto.ProdutoID == ProdutoID);
                var subtotalProd = query.Sum(o => o.PrecoProduto);
                var query2 = Configs.Where(Config => Config.ConfigID == ConfigID);
                var subtotalConfig = Quant_Config * query2.Sum(o => o.precototal);
                return subtotalConfig + subtotalProd;
            }
        }


        public virtual ICollection<Config> Configs { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Config Config { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual Loja Loja { get; set; }
    }
}