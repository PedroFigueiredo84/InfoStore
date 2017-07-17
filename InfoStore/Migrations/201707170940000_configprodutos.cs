namespace InfoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configprodutos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteID = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(),
                        LojaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteID)
                .ForeignKey("dbo.Lojas", t => t.LojaID, cascadeDelete: true)
                .Index(t => t.LojaID);
            
            CreateTable(
                "dbo.Lojas",
                c => new
                    {
                        LojaID = c.Int(nullable: false, identity: true),
                        Cidade = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.LojaID);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        FuncionarioID = c.Int(nullable: false, identity: true),
                        NomeFuncionario = c.String(),
                        LojaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FuncionarioID);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        CompraID = c.Int(nullable: false, identity: true),
                        Quant = c.Int(nullable: false),
                        LojaID = c.Int(nullable: false),
                        ProdutoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompraID)
                .ForeignKey("dbo.Lojas", t => t.LojaID, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoID, cascadeDelete: true)
                .Index(t => t.LojaID)
                .Index(t => t.ProdutoID);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        NomeProduto = c.String(),
                        CustoProduto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecoProduto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDConfig = c.Int(),
                        Compra_CompraID = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoID)
                .ForeignKey("dbo.Configs", t => t.IDConfig)
                .ForeignKey("dbo.Compras", t => t.Compra_CompraID)
                .Index(t => t.IDConfig)
                .Index(t => t.Compra_CompraID);
            
            CreateTable(
                "dbo.Configs",
                c => new
                    {
                        ConfigID = c.Int(nullable: false, identity: true),
                        PrecoConfig = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ConfigID);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaID = c.Int(nullable: false, identity: true),
                        FuncionarioID = c.Int(nullable: false),
                        ProdutoID = c.Int(),
                        ConfigID = c.Int(),
                        Quant_Prod = c.Int(),
                        Quant_Config = c.Int(),
                        Loja_LojaID = c.Int(),
                    })
                .PrimaryKey(t => t.FacturaID)
                .ForeignKey("dbo.Configs", t => t.ConfigID)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioID, cascadeDelete: true)
                .ForeignKey("dbo.Lojas", t => t.Loja_LojaID)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoID)
                .Index(t => t.FuncionarioID)
                .Index(t => t.ProdutoID)
                .Index(t => t.ConfigID)
                .Index(t => t.Loja_LojaID);
            
            CreateTable(
                "dbo.FuncionarioLojas",
                c => new
                    {
                        Funcionario_FuncionarioID = c.Int(nullable: false),
                        Loja_LojaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Funcionario_FuncionarioID, t.Loja_LojaID })
                .ForeignKey("dbo.Funcionarios", t => t.Funcionario_FuncionarioID, cascadeDelete: true)
                .ForeignKey("dbo.Lojas", t => t.Loja_LojaID, cascadeDelete: true)
                .Index(t => t.Funcionario_FuncionarioID)
                .Index(t => t.Loja_LojaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "ProdutoID", "dbo.Produtoes");
            DropForeignKey("dbo.Facturas", "Loja_LojaID", "dbo.Lojas");
            DropForeignKey("dbo.Facturas", "FuncionarioID", "dbo.Funcionarios");
            DropForeignKey("dbo.Facturas", "ConfigID", "dbo.Configs");
            DropForeignKey("dbo.Produtoes", "Compra_CompraID", "dbo.Compras");
            DropForeignKey("dbo.Compras", "ProdutoID", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "IDConfig", "dbo.Configs");
            DropForeignKey("dbo.Compras", "LojaID", "dbo.Lojas");
            DropForeignKey("dbo.Clientes", "LojaID", "dbo.Lojas");
            DropForeignKey("dbo.FuncionarioLojas", "Loja_LojaID", "dbo.Lojas");
            DropForeignKey("dbo.FuncionarioLojas", "Funcionario_FuncionarioID", "dbo.Funcionarios");
            DropIndex("dbo.FuncionarioLojas", new[] { "Loja_LojaID" });
            DropIndex("dbo.FuncionarioLojas", new[] { "Funcionario_FuncionarioID" });
            DropIndex("dbo.Facturas", new[] { "Loja_LojaID" });
            DropIndex("dbo.Facturas", new[] { "ConfigID" });
            DropIndex("dbo.Facturas", new[] { "ProdutoID" });
            DropIndex("dbo.Facturas", new[] { "FuncionarioID" });
            DropIndex("dbo.Produtoes", new[] { "Compra_CompraID" });
            DropIndex("dbo.Produtoes", new[] { "IDConfig" });
            DropIndex("dbo.Compras", new[] { "ProdutoID" });
            DropIndex("dbo.Compras", new[] { "LojaID" });
            DropIndex("dbo.Clientes", new[] { "LojaID" });
            DropTable("dbo.FuncionarioLojas");
            DropTable("dbo.Facturas");
            DropTable("dbo.Configs");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Compras");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Lojas");
            DropTable("dbo.Clientes");
        }
    }
}
