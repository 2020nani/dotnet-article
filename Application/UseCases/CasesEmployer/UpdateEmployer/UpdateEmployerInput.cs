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
            actualEmployer.Payment = Payment is null ? actualEmployer.Payment : Payment;
            actualEmployer.Nome = Nome is null ? actualEmployer.Nome : Nome;
            actualEmployer.Cargo = Cargo is null ? actualEmployer.Cargo : Cargo;
            return actualEmployer;
        }
    }
}
