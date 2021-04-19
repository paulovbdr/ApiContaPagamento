using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class ContaEntity : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(80)]
        public string Description { get; set; }

        public decimal Balance { get; set; }

        [Required]
        public bool Status { get; set; }

    }
}
