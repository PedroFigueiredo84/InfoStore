using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfoStore.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string NomeProduto { get; set; }
        public decimal CustoProduto { get; set; }
        public decimal PrecoProduto { get; set; }


        //Alternativa
        public decimal margemlucro { get {return PrecoProduto - CustoProduto;} }

        [ForeignKey("Config")]
        public int IDConfig { get; set; }

        public virtual Config Config { get; set; }



    }
}