using System.Numerics;

namespace FirstApi.Domain.ValueObjects
{
    public class Payment
    {
        public BigInteger salary { get; set; }
        public BigInteger benefits { get; set; }

        public BigInteger getPaymentTotal()
        {
            return salary + benefits;
    }
    }

}
