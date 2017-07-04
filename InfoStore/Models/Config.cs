using System.Collections.Generic;
using System.Data.Entity;
using InfoStore.Models;
using System.Linq;
using System.Collections;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InfoStore.Models
{
    public class Config
    {
        [Key]
        public int ConfigID { get; set; }

        //preço de configurar
        public decimal PrecoConfig { get; set; }

        // lista dos produtos

        public IList<int> ProdutosSelecionados { get; set; }
        public IList<SelectListItem> Prod_Disponiveis { get; set; }

        public Config()
        {
            ProdutosSelecionados = new List<int>();
            Prod_Disponiveis = new List<SelectListItem>();
        }

        //Custo dos produtos

        public decimal custoProdutos
        {
            get
            {
                var query = Produtos.Where(Produto => Produto.IDConfig == ConfigID);
                return query.Sum(o => o.CustoProduto);
            }
        }


        //Preço dos produtos

        public decimal precoProdutos
        {
            get
            {
                var query1 = Produtos.Where(Produto => Produto.IDConfig == ConfigID);
                return query1.Sum(o => o.PrecoProduto);
            }
        }

        //Preço Total

        public decimal precototal { get { return precoProdutos + PrecoConfig; } }


        public virtual ICollection<Produto> Produtos { get; set; }
    }



}