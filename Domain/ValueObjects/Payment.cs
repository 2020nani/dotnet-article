using System.Numerics;

namespace FirstApi.Domain.ValueObjects
{
    public class Payment
    {
        public double salary { get; set; }
        public double benefits { get; set; }

        public double getPaymentTotal()
        {
            return salary + benefits;
    }
    }

}
