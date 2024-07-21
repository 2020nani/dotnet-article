using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;

namespace FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer
{
    public class UpdateEmployerInput
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cargo { get; set; }
        public Payment? Payment { get; set; }

        internal Employer Convert(Employer actualEmployer)
        {
            actualEmployer.payment = Payment is null ? actualEmployer.payment : Payment;
            actualEmployer.Nome = Nome is null ? actualEmployer.Nome : Nome;
            actualEmployer.cargo = Cargo is null ? actualEmployer.cargo : Cargo;
            return actualEmployer;
        }
    }
}
