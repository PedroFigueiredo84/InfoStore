using System.Collections.Generic;
using System.Data.Entity;
using InfoStore.Models;
using System.Linq;

namespace InfoStore.Models
{
    public class Config
    {
        public int ConfigID { get; set; }
        
        //preço de configurar
        public decimal PrecoConfig { get; set; }

        // lista dos produtos

        public Config()
        {
            Produtos = new List<Produto>();
        }


        //Custo dos produtos

        public decimal custoProdutos { get {
                var query = Produtos.Where(Produto => Produto.IDConfig > ConfigID);
                return query.Sum(o => o.CustoProduto); } }


        
        //Preço dos produtos

        public decimal precoProdutos { get {
                var query1 = Produtos.Where(Produto => Produto.IDConfig > ConfigID);
                return query1.Sum(o => o.PrecoProduto);
            }
        }

        //Preço Total

        public decimal precototal { get { return precoProdutos - custoProdutos + PrecoConfig; } }


        public virtual ICollection<Produto> Produtos { get; set; }
    }

    

}