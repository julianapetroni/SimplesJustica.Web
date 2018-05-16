namespace SimplesJustica.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationCriacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                        Sobrenome = c.String(maxLength: 100, unicode: false),
                        CPF = c.String(maxLength: 11, unicode: false),
                        Nascimento = c.DateTime(storeType: "date"),
                        Genero = c.String(maxLength: 15, unicode: false),
                        NomeFantasia = c.String(maxLength: 300, unicode: false),
                        CNPJ = c.String(maxLength: 14, unicode: false),
                        InscricaoEstadual = c.String(maxLength: 50, unicode: false),
                        LinhaDeNegocio = c.Int(),
                        Type = c.String(nullable: false, maxLength: 7, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "EmailUnique")
                .Index(t => t.CPF, unique: true, name: "CpfUnique")
                .Index(t => t.CNPJ, unique: true, name: "CnpjUnique");
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 15, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 150, unicode: false),
                        UF = c.String(nullable: false, maxLength: 2, unicode: false),
                        Pais = c.String(nullable: false, maxLength: 100, unicode: false),
                        CEP = c.String(nullable: false, maxLength: 9, unicode: false),
                        Principal = c.Boolean(),
                        UsuarioId = c.Guid(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autor", t => t.UsuarioId)
                .ForeignKey("dbo.Conciliador", t => t.UsuarioId)
                .ForeignKey("dbo.Reu", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Reclamacao",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 150, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 300, unicode: false),
                        Status = c.Int(nullable: false),
                        AutorId = c.Guid(nullable: false),
                        ReuId = c.Guid(nullable: false),
                        ConciliadorId = c.Guid(),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autor", t => t.AutorId)
                .ForeignKey("dbo.Conciliador", t => t.ConciliadorId)
                .ForeignKey("dbo.Reu", t => t.ReuId)
                .Index(t => t.AutorId)
                .Index(t => t.ReuId)
                .Index(t => t.ConciliadorId);
            
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 30, unicode: false),
                        Sobrenome = c.String(nullable: false, maxLength: 100, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 11, unicode: false),
                        Nascimento = c.DateTime(nullable: false, storeType: "date"),
                        Genero = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CPF, unique: true, name: "CpfUnique")
                .Index(t => t.Email, unique: true, name: "EmailUnique");
            
            CreateTable(
                "dbo.Conciliador",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataAtualizacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "EmailUnique");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reclamacao", "ReuId", "dbo.Reu");
            DropForeignKey("dbo.Endereco", "UsuarioId", "dbo.Reu");
            DropForeignKey("dbo.Reclamacao", "ConciliadorId", "dbo.Conciliador");
            DropForeignKey("dbo.Endereco", "UsuarioId", "dbo.Conciliador");
            DropForeignKey("dbo.Reclamacao", "AutorId", "dbo.Autor");
            DropForeignKey("dbo.Endereco", "UsuarioId", "dbo.Autor");
            DropIndex("dbo.Conciliador", "EmailUnique");
            DropIndex("dbo.Autor", "EmailUnique");
            DropIndex("dbo.Autor", "CpfUnique");
            DropIndex("dbo.Reclamacao", new[] { "ConciliadorId" });
            DropIndex("dbo.Reclamacao", new[] { "ReuId" });
            DropIndex("dbo.Reclamacao", new[] { "AutorId" });
            DropIndex("dbo.Endereco", new[] { "UsuarioId" });
            DropIndex("dbo.Reu", "CnpjUnique");
            DropIndex("dbo.Reu", "CpfUnique");
            DropIndex("dbo.Reu", "EmailUnique");
            DropTable("dbo.Conciliador");
            DropTable("dbo.Autor");
            DropTable("dbo.Reclamacao");
            DropTable("dbo.Endereco");
            DropTable("dbo.Reu");
        }
    }
}
