using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace EmpregaSENAI.Models
{
    public class Curriculo 
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Nome:")]
        public string Nome { get; set; }

        public int Idade { get; set; }

        [Display(Name = "Data de Nascimento:")]
        public int DataNascimento { get; set; }

        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }

        [Display(Name = "Endereco:")]
        public string Endereco { get; set; }

        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }

        [Display(Name = "CEP:")]
        public string CEP { get; set; }

        [Required, Display(Name = "Email:")]
        public string Email { get; set; }

        [Display(Name = "Cargo Interesse:")]
        public string CargoInteresse { get; set; }

        [Display(Name = "Instituição:")]
        public string Instituicao { get; set; }

        [Display(Name = "Grau Formação:")]
        public string GrauFormacao { get; set; }

        [Display(Name = "Nome do Curso:")]
        public string NomeCurso { get; set; }

        [Display(Name = "Duração:")]
        public string Duracao { get; set; }

        [Display(Name = "Ano de Conclusão:")]
        public int AnoConclusao { get; set; }

    }
}
                    