namespace AlunoCurso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlunoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Telefone = c.String(),
                        Email = c.String(),
                        Sexo = c.String(),
                        Curso_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CursoModels", t => t.Curso_Id)
                .Index(t => t.Curso_Id);
            
            CreateTable(
                "dbo.CursoModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Curso = c.String(nullable: false),
                        CH = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlunoModels", "Curso_Id", "dbo.CursoModels");
            DropIndex("dbo.AlunoModels", new[] { "Curso_Id" });
            DropTable("dbo.CursoModels");
            DropTable("dbo.AlunoModels");
        }
    }
}
