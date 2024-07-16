using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApi.Application.UseCases.CasesEmployer.ConsultEmployer
{
    public class ConsultEmployerOutput
    {
        public int _Id { get; set; }
        public string? _Nome { get; set; }
        public string? _Cargo { get; set; }
        public Payment? _Payment { get; set; }
        public double? _PaymentTotal { get; set; }

        public ConsultEmployerOutput convert(Employer employer)
        {
            _Id = employer.Id;
            _Nome = employer.Nome;
            _Cargo = employer.cargo;
            _Payment = employer.payment;
            _PaymentTotal = employer.paymentTotal;
            return this;
        }
    }
}
