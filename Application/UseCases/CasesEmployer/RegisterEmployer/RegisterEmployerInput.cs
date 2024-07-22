
using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;

namespace FirstApi.Application.UseCases.CasesEmployer.Register
{
    public class RegisterEmployerInput
    {
        public string? Nome { get; set; }
        public string? Cargo { get; set; }
        public Payment? Payment { get; set; }
        public double? Premiation { get; set; }
        public Employer Convert()
        {
            Employer employer = new Employer();
            employer.Nome = Nome;
            employer.Cargo = Cargo;
            employer.Payment = Payment;
            employer.PaymentTotal = Payment?.getPaymentTotal();
            if ( Premiation != null) {
                employer.AddPaymentByPremiation((double)Premiation);
            }
            return employer;
        }
    }
}
