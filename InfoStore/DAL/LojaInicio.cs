using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using InfoStore.Models;

namespace InfoStore.DAL
{
    public class LojaInicio : System.Data.Entity.DropCreateDatabaseIfModelChanges<LojaDB>
    {
        protected override void Seed(LojaDB context)
        {
            var lojas = new List<Loja>
            {
            new Loja{LojaID=1, Cidade="Lisboa"},
            new Loja{LojaID=2, Cidade="Porto"}
            };

            lojas.ForEach(s => context.Lojas.Add(s));
            context.SaveChanges();

            var clientes = new List<Cliente>
            {
            new Cliente{ClienteID=1, NomeCliente="João",LojaID=1},
            new Cliente{ClienteID=2, NomeCliente="Paulo",LojaID=1},
            new Cliente{ClienteID=3, NomeCliente="Carlos",LojaID=2},
            new Cliente{ClienteID=4, NomeCliente="Luis",LojaID=2},
            new Cliente{ClienteID=4, NomeCliente="Pedro",LojaID=2}
            };
            clientes.ForEach(s => context.Clientes.Add(s));
            context.SaveChanges();
        }
    }
}




