namespace AlunoCurso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterAluno : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AlunoModels", name: "Curso_Id", newName: "CursoId");
            RenameIndex(table: "dbo.AlunoModels", name: "IX_Curso_Id", newName: "IX_CursoId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AlunoModels", name: "IX_CursoId", newName: "IX_Curso_Id");
            RenameColumn(table: "dbo.AlunoModels", name: "CursoId", newName: "Curso_Id");
        }
    }
}
