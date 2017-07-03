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
            //produtos = new list<produto>();
            //configs = new list<config>();
        }

        public int FacturaID { get; set; }

        [ForeignKey("Funcionario")]
        public int FuncionarioID { get; set; }

        [ForeignKey("Produto")]
        public int? ProdutoID { get; set; }

        [ForeignKey("Config")]
        public int? ConfigID { get; set; }

        public int? Quant_Prod { get; set; }
        public int? Quant_Config { get; set; }

        public decimal? total_factura
        {
            get
            {
                decimal? subtotalProd = Quant_Prod * Produto?.PrecoProduto;
                decimal? subtotalConfig = Quant_Config * Config?.precototal;
                if (subtotalProd == null)
                {
                    return subtotalConfig;
                }
                else if (subtotalConfig == null)
                {
                    return subtotalProd;
                }
                else
                {
                    return subtotalConfig + subtotalProd;
                }
            }
        }


        //public virtual ICollection<Config> Configs { get; set; }
        //public virtual ICollection<Produto> Produtos { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Config Config { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual Loja Loja { get; set; }
    }
}