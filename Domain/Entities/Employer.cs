﻿using FirstApi.Domain.ValueObjects;
using System.Numerics;

namespace FirstApi.Domain.Entities
{
    public class Employer
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? cargo { get; set; }
        public Payment? payment { get; set; }
        public double? paymentTotal { get; set; }

        public void addPaymentByPremiation(double premiation)
        {
            paymentTotal = paymentTotal + premiation;
        }
    }
}
