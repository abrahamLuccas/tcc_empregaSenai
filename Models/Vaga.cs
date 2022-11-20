using System.ComponentModel.DataAnnotations;

namespace EmpregaSENAI.Models
{
    public class Vaga
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Descrição da vaga")]
        public string Desc { get; set; }

        [Display(Name = "Setor")]
        public string Setor { get; set; }

        [Display(Name = "Requisitos")]
        public string Requisitos { get; set; }

        [Display(Name = "Informações adicionais")]
        public string Infos { get; set; }


    }
}
