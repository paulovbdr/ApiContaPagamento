using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Lancamento
{
    public class LancamentoDtoCreate
    {
        [Required(ErrorMessage = "Id da conta é campo Obrigatorio")]
        public Guid ContaId { get; set; }

        [Required(ErrorMessage = "Descrição é campo obrigatório.")]
        [StringLength(100, ErrorMessage = "Descrição deve ter no máximo {1} caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Valor é campo obrigatório.")]
        public decimal Value { get; set; }
    }
}
