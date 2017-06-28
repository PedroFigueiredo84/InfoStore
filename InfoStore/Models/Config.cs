using System.Collections.Generic;
using System.Data.Entity;
using InfoStore.Models;

namespace InfoStore.Models
{
    public class Config
    {
        


        public int ConfigID { get; set; }
        
        //preço de configurar
        public decimal PrecoConfig { get; set; }
        
        //custo dos produtos da configuração

        // lista dos produtos

        public Config()
        {
            Produtos = new List<Produto>();
        }


        //Preço dos produtos

        // public decimal precoProdutos { get { return ListaProdutos.Sum(o => o.PrecoProduto); } }

        //Preço Total

        // public decimal precototal { get { return precoProdutos - custoProdutos; } }

        public int CustoProduto { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; } // aqui é um navegador para acessar uma lista de produtos
    }

    

}