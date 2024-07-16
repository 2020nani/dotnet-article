using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;

namespace FirstApi.Application.UseCases.CasesEmployer.UpdateEmployer
{
    public class UpdateEmployerInput
    {
        public int _Id { get; set; }
        public string? _Nome { get; set; }
        public string? _Cargo { get; set; }
        public Payment? _Payment { get; set; }

        internal Employer updateEmployer(Employer actualEmployer)
        {
            actualEmployer.payment = _Payment is null ? actualEmployer.payment : _Payment;
            actualEmployer.Nome = _Nome is null ? actualEmployer.Nome : _Nome;
            actualEmployer.cargo = _Cargo is null ? actualEmployer.cargo : _Cargo;
            return actualEmployer;
        }
    }
}
