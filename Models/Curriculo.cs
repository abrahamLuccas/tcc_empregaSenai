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

        public string? FK_UserId { get; set; }

        [Required, Display(Name = "Nome:")]
        public string? Nome { get; set; }

        [Required, Display(Name = "Data de Nascimento:")]
        public int? DataNascimento { get; set; }

        /*[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; } 
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]

        [Required]
        [StringLength(50, MinimumLength=2)]
         
         [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
         
        possiveis melhorias e validações
         */

        [Required, Display(Name = "Telefone:")]
        public string? Telefone { get; set; }

        [Required, Display(Name = "Endereco:")]
        public string? Endereco { get; set; }

        [Display(Name = "Bairro:")]
        public string? Bairro { get; set; }

        [Display(Name = "Cidade:")]
        public string? Cidade { get; set; }

        [Display(Name = "CEP:")]
        public string? CEP { get; set; }

        [Required, Display(Name = "Email:")]
        public string? Email { get; set; }

        [Required, Display(Name = "Cargo Interesse:")]
        public string? CargoInteresse { get; set; }

        [Required, Display(Name = "Instituição:")]
        public string? Instituicao { get; set; }

        [Required, Display(Name = "Resumo:")]
        public string? Resumo { get; set; }

        [Required, Display(Name = "Grau Formação:")]
        public string? GrauFormacao { get; set; }

        [Required, Display(Name = "Nome do Curso:")]
        public string? NomeCurso { get; set; }

        [Required, Display(Name = "Duração:")]
        public string? Duracao { get; set; }

        [Required, Display(Name = "Ano de Conclusão:")]
        public int? AnoConclusao { get; set; }

    }
}
