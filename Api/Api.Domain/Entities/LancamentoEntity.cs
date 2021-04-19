using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class LancamentoEntity : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public decimal Value { get; set; }

        [ForeignKey("Conta")]
        [Required]
        public Guid ContaId { get; set; }
        public ContaEntity Conta { get; set; }

    }
}
