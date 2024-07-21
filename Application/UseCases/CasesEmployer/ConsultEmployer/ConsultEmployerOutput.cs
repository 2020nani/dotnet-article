using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstApi.Application.UseCases.CasesEmployer.ConsultEmployer
{
    public class ConsultEmployerOutput
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cargo { get; set; }
        public Payment? Payment { get; set; }
        public double? PaymentTotal { get; set; }

        public ConsultEmployerOutput Convert(Employer employer)
        {
            Id = employer.Id;
            Nome = employer.Nome;
            Cargo = employer.cargo;
            Payment = employer.payment;
            PaymentTotal = employer.paymentTotal;
            return this;
        }
    }
}
