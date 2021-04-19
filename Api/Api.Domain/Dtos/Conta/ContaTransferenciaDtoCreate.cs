using System;

namespace Api.Domain.Dtos.Conta
{
    public class ContaTransferenciaDtoCreate
    {
        public Guid ContaIdOrigem { get; set; }

        public Guid ContaIdDestino { get; set; }

        public decimal ValorTransferencia { get; set; }
    }
}
