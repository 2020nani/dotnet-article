using System.Numerics;

namespace FirstApi.Domain.ValueObjects
{
    public class Payment
    {
        public double Salary { get; set; }
        public double Benefits { get; set; }

        public double getPaymentTotal()
        {
            return Salary + Benefits;
    }
    }

}
