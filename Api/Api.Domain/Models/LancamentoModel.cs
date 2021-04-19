using System;

namespace Api.Domain.Models
{
    public class LancamentoModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Guid _contaId;
        public Guid ContaId
        {
            get { return _contaId; }
            set { _contaId = value; }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private decimal _value;

        public decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }

        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }
    }
}
