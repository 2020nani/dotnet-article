using FirstApi.Domain.ValueObjects;

namespace FirstApi.Domain.Entities
{
    public class Employer
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cargo { get; set; }

        public Payment? Payment { get; set; }
        public double? PaymentTotal { get; set; }

        public void AddPaymentByPremiation(double premiation)
        {
            PaymentTotal = PaymentTotal + premiation;
        }
    }
}
