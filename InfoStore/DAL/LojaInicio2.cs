using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using InfoStore.Models;

namespace InfoStore.DAL
{
    public class LojaInicio2 : System.Data.Entity.DropCreateDatabaseIfModelChanges<LojaDB>
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

            var funcionarios = new List<Funcionario>
            {
            new Funcionario{FuncionarioID=1, NomeFuncionario="JoseA",LojaID=1},
            new Funcionario{FuncionarioID=2, NomeFuncionario="JoseB",LojaID=1},
            new Funcionario{FuncionarioID=3, NomeFuncionario="JoseC",LojaID=1},
            new Funcionario{FuncionarioID=4, NomeFuncionario="JoseD",LojaID=2},
            new Funcionario{FuncionarioID=5, NomeFuncionario="JoseE",LojaID=2},
            new Funcionario{FuncionarioID=6, NomeFuncionario="JoseF",LojaID=2}
            };
            funcionarios.ForEach(s => context.Funcionarios.Add(s));
            context.SaveChanges();

            var config = new List<Config>()
               {
                new Config { ConfigID = 1, PrecoConfig = 50 },
              new Config { ConfigID = 2, PrecoConfig = 40 },
              new Config { ConfigID = 3, PrecoConfig = 10 }
             };
            config.ForEach(c => context.Configs.Add(c));
            context.SaveChanges();

            var produtos = new List<Produto>
            {
            new Produto{ProdutoID=1, NomeProduto="Teclado",CustoProduto=5, PrecoProduto=10, IDConfig=1},
            new Produto{ProdutoID=2, NomeProduto="Monitor",CustoProduto=4, PrecoProduto=8, IDConfig=1},
            new Produto{ProdutoID=3, NomeProduto="Rato",CustoProduto=3, PrecoProduto=6, IDConfig=2},
            new Produto{ProdutoID=4, NomeProduto="Scanner",CustoProduto=2, PrecoProduto=9, IDConfig=3},
            };
            produtos.ForEach(s => context.Produtos.Add(s));
            context.SaveChanges();
        }
    }
}
