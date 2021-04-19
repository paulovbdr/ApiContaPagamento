using System;

namespace Api.Domain.Dtos.Conta
{
    public class ContaDtoCreateResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
