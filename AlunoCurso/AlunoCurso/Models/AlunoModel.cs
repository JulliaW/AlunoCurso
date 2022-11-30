using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlunoCurso.Models
{
    public class AlunoModel
    {
        [key]
        [Display(Name = "ID:")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [Display(Name = "Telefone: ")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail: ")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Display(Name = "Sexo: ")]
        public string Sexo { get; set; }

        public int? CursoId { get; set; }

        public CursoModel Curso { get; set; }

    }
}