
using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;

namespace FirstApi.Application.UseCases.CasesEmployer.Register
{
    public class RegisterEmployerInput
    {
        public string? _Nome { get; set; }
        public string? _Cargo { get; set; }
        public Payment? _Payment { get; set; }
        public double? _Premiation { get; set; }
        public Employer convert()
        {
            Employer employer = new Employer();
            employer.Nome = _Nome;
            employer.cargo = _Cargo;
            employer.payment = _Payment;
            employer.paymentTotal = _Payment?.getPaymentTotal();
            if ( _Premiation != null) {
                employer.addPaymentByPremiation((double)_Premiation);
            }
            return employer;
        }
    }
}
