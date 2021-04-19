using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Conta
{
    public class ContaDtoCreate
    {
        [Required(ErrorMessage = "Nome é campo obrigatório")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Descrição é campo obrigatório.")]
        [StringLength(80, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Status é campo obrigatório.")]
        public bool Status { get; set; }

    }
}
