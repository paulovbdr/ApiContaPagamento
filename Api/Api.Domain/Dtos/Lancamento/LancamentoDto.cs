using System;

namespace Api.Domain.Dtos.Lancamento
{
    public class LancamentoDto
    {
        public Guid Id { get; set; }

        public Guid ContaId { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
