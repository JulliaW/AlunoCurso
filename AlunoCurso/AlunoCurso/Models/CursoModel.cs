using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlunoCurso.Models
{
    public class CursoModel
    {
        [key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do curso")]
        [Display(Name = "Nome do curso: ")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Informe a carga horária")]
        [Display(Name ="Carga horária: ")]

        public string CH { get; set; }

        public virtual ICollection<AlunoModel> Alunos { get; set; }

    }
}