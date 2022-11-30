using AlunoCurso.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlunoCurso.Context
{
    public class Contexto : DbContext
    {
        public Contexto() : base("dbAlunoCurso")
        {

        }
        public DbSet<AlunoModel> Alunos { get; set; }

        public DbSet<CursoModel> Cursos { get; set; }

    }
}