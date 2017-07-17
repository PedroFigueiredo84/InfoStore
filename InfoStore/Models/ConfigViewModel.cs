using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoStore.Models
{
    public class ConfigViewModel
    {
        // lista dos produtos

        public IList<int> ProdutosSelecionados { get; set; }
        public IList<SelectListItem> Prod_Disponiveis { get; set; }
        public decimal PrecoConfig { get; set; }

        public Config Config { get; set; }

        public ConfigViewModel()
        {
            ProdutosSelecionados = new List<int>();

            Prod_Disponiveis = new List<SelectListItem>();
        }

    }
}